using AutoMapper;
using LFR.Core.Dtos;
using LFR.Core.Exceptions;
using LFR.Core.ViewModel;
using LFR.Data.Models;
using LFR.Infrastructure.Services.CourtFees;
using LFR.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Infrastructure.Services.CourtRequests
{
    public class CourtRequestService : ICourtRequestService
    {
        private readonly LFRDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICourtFeeService _courtFeeService;
        private readonly IFileService _fileService;


        public CourtRequestService(LFRDbContext db, IMapper mapper, ICourtFeeService courtFeeService, IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _courtFeeService = courtFeeService;
            _fileService = fileService;
        }


        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.CourtRequests.Include(x => x.Issue).Include(x => x.CourtFee).Where(x => !x.IsDelete && (x.Type.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var courtRequest = _mapper.Map<List<CourtRequestViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = courtRequest,
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


        public async Task<int> Create(CreateCourtRequestDto dto)
        {
            var courtRequest = _mapper.Map<CourtRequest>(dto);
            if (dto.Image != null)
            {
                courtRequest.ImageUrl = await _fileService.SaveFile(dto.Image, "CourtRequests");
            }
            await _db.CourtRequests.AddAsync(courtRequest);
            await _db.SaveChangesAsync();
            if (courtRequest.CourtFeeId == null)
            {
                var courtFeeIdId = await _courtFeeService.Create(dto.CourtFee);
                courtRequest.CourtFeeId = courtFeeIdId;

                _db.CourtRequests.Update(courtRequest);
                await _db.SaveChangesAsync();

            }

            return courtRequest.Id;
        }

        public async Task<int> Update(UpdateCourtRequestDto dto)
        {
            var courtRequest = await _db.CourtRequests.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if (courtRequest == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedCourtRequest = _mapper.Map<UpdateCourtRequestDto, CourtRequest>(dto, courtRequest);
            if (dto.Image != null)
            {
                courtRequest.ImageUrl = await _fileService.SaveFile(dto.Image, "CourtRequests");
            }
            _db.CourtRequests.Update(updatedCourtRequest);
            await _db.SaveChangesAsync();
            return updatedCourtRequest.Id;
        }


        public async Task<UpdateCourtRequestDto> Get(int Id)
        {
            var courtRequest = await _db.CourtRequests.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (courtRequest == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateCourtRequestDto>(courtRequest);
        }
        public async Task<int> Delete(int Id)
        {
            var courtRequest = await _db.CourtRequests.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (courtRequest == null)
            {
                throw new EntityNotFoundException();
            }
            courtRequest.IsDelete = true;
            _db.CourtRequests.Update(courtRequest);
            await _db.SaveChangesAsync();
            return courtRequest.Id;
        }


    }
}
