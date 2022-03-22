using AutoMapper;
using LFR.Core.Dtos;
using LFR.Core.Exceptions;
using LFR.Core.ViewModel;
using LFR.Data.Models;
using LFR.Infrastructure.Services.LawyerCharges;
using LFR.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Infrastructure.Services.Contracts
{
  public  class ContractService : IContractService
    {
        private readonly LFRDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILawyerChargeService _lawyerChargeService;
        private readonly IFileService _fileService;


        public ContractService(LFRDbContext db, IMapper mapper , ILawyerChargeService lawyerChargeService , IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _lawyerChargeService = lawyerChargeService;
            _fileService = fileService;
        }


        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Contracts.Include(x => x.LawyerCharge).Include(x => x.Category).Where(x => !x.IsDelete && (x.FirstParty.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var categories = _mapper.Map<List<ContractViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = categories,
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    pages = pages,
                    total = dataCount,
                }
            };
            return result;
        }


        public async Task<int> Create(CreateContractDto dto)
        {
            var contract = _mapper.Map<Contract>(dto);
            if (dto.Image != null)
            {
                contract.ImageUrl = await _fileService.SaveFile(dto.Image, "Contracts");
            }
            await _db.Contracts.AddAsync(contract);
            await _db.SaveChangesAsync();
            if (contract.LawyerChargeId == null)
            {
                var lawyerChargeId = await _lawyerChargeService.Create(dto.LawyerCharge);
                contract.LawyerChargeId = lawyerChargeId;

                _db.Contracts.Update(contract);
                await _db.SaveChangesAsync();

            }

            return contract.Id;
        }

        public async Task<int> Update(UpdateContractDto dto)
        {
            var contract = await _db.Contracts.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if (contract == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedContract = _mapper.Map<UpdateContractDto, Contract>(dto, contract);
            if (dto.Image != null)
            {
                contract.ImageUrl = await _fileService.SaveFile(dto.Image, "Contracts");
            }
            _db.Contracts.Update(updatedContract);
            await _db.SaveChangesAsync();
            return updatedContract.Id;
        }

        public async Task<UpdateContractDto> Get(int Id)
        {
            var contract = await _db.Contracts.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (contract == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateContractDto>(contract);
        }
        public async Task<int> Delete(int id)
        {
            var contracts = await _db.Contracts.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (contracts == null)
            {
                throw new EntityNotFoundException();
            }
            contracts.IsDelete = true;
            _db.Contracts.Update(contracts);
            await _db.SaveChangesAsync();
            return contracts.Id;
        }


    }
}
