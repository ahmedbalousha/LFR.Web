using AutoMapper;
using LFR.Core.Dtos;
using LFR.Core.Exceptions;
using LFR.Core.ViewModel;
using LFR.Data.Models;
using LFR.Infrastructure.Services.Categories;
using LFR.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Infrastructure.Services.LawyerCharges
{
    public class LawyerChargeService : ILawyerChargeService
    {
        private readonly LFRDbContext _db;
        private readonly IMapper _mapper;

        public LawyerChargeService(LFRDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.LawyerCharges.Where(x => !x.IsDelete && (x.PayFor.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var lawyerCharges = _mapper.Map<List<LawyerChargeViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = lawyerCharges,
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


        public async Task<int> Create(CreateLawyerChargeDto dto)
        {
            var lawyerCharge = _mapper.Map<LawyerCharge>(dto);
            await _db.LawyerCharges.AddAsync(lawyerCharge);
            await _db.SaveChangesAsync();
            return lawyerCharge.Id;
        }


        public async Task<int> Update(UpdateLawyerChargeDto dto)
        {
            var lawyerCharge = await _db.LawyerCharges.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if (lawyerCharge == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedLawyerCharge = _mapper.Map<UpdateLawyerChargeDto, LawyerCharge>(dto, lawyerCharge);
            _db.LawyerCharges.Update(updatedLawyerCharge);
            await _db.SaveChangesAsync();
            return updatedLawyerCharge.Id;
        }


        public async Task<UpdateLawyerChargeDto> Get(int Id)
        {
            var lawyerCharge = await _db.LawyerCharges.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (lawyerCharge == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateLawyerChargeDto>(lawyerCharge);
        }


        public async Task<int> Delete(int id)
        {
            var lawyerCharge = await _db.LawyerCharges.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (lawyerCharge == null)
            {
                throw new EntityNotFoundException();
            }
            lawyerCharge.IsDelete = true;
            _db.LawyerCharges.Update(lawyerCharge);
            await _db.SaveChangesAsync();
            return lawyerCharge.Id;
        }


    }
}
