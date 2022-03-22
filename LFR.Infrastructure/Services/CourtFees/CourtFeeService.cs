using AutoMapper;
using LFR.Core.Dtos;
using LFR.Core.Exceptions;
using LFR.Core.ViewModel;
using LFR.Data.Models;
using LFR.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Infrastructure.Services.CourtFees
{
    public class CourtFeeService : ICourtFeeService
    {
        private readonly LFRDbContext _db;
        private readonly IMapper _mapper;

        public CourtFeeService(LFRDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.CourtFees.Where(x => !x.IsDelete && (x.PayFor.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var courtFees = _mapper.Map<List<CourtFeeViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = courtFees,
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


        public async Task<int> Create(CreateCourtFeeDto dto)
        {
            var courtFee = _mapper.Map<CourtFee>(dto);
            await _db.CourtFees.AddAsync(courtFee);
            await _db.SaveChangesAsync();
            return courtFee.Id;
        }


        public async Task<int> Update(UpdateCourtFeeDto dto)
        {
            var courtFee = await _db.CourtFees.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if (courtFee == null)
            {
                //throw new EntityNotFoundException();
            }
            var updatedCourtFee = _mapper.Map<UpdateCourtFeeDto, CourtFee>(dto, courtFee);
            _db.CourtFees.Update(updatedCourtFee);
            await _db.SaveChangesAsync();
            return updatedCourtFee.Id;
        }


        public async Task<UpdateCourtFeeDto> Get(int Id)
        {
            var courtFee = await _db.CourtFees.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (courtFee == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateCourtFeeDto>(courtFee);
        }


        public async Task<int> Delete(int Id)
        {
            var courtFee = await _db.CourtFees.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (courtFee == null)
            {
                throw new EntityNotFoundException();
            }
            courtFee.IsDelete = true;
            _db.CourtFees.Update(courtFee);
            await _db.SaveChangesAsync();
            return courtFee.Id;
        }


    }
}

