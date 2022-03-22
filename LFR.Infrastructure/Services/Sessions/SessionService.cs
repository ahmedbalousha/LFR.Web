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

namespace LFR.Infrastructure.Services.Sessions
{
    public class SessionService : ISessionService
    {
        private readonly LFRDbContext _db;
        private readonly IMapper _mapper;

        public SessionService(LFRDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


       
        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Sessions/*.Include(x=> x.Issue)*/.Where(x => !x.IsDelete ).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var categories = _mapper.Map<List<SessionViewModel>>(dataList);
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


        public async Task<int> Create(CreateSessionDto dto)
        {
            var session = _mapper.Map<Session>(dto);
            await _db.Sessions.AddAsync(session);
            await _db.SaveChangesAsync();
            return session.Id;
        }


        public async Task<int> Update(UpdateSessionDto dto)
        {
            var session = await _db.Sessions.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if(session == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedSession = _mapper.Map<UpdateSessionDto, Session>(dto, session);
            _db.Sessions.Update(updatedSession);
            await _db.SaveChangesAsync();
            return updatedSession.Id;
        }


        public async Task<UpdateSessionDto> Get(int Id)
        {
            var session = await _db.Sessions.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (session == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateSessionDto>(session);
        }


        public async Task<int> Delete(int Id)
        {
            var session = await _db.Sessions.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (session == null)
            {
                throw new EntityNotFoundException();
            }
            session.IsDelete = true;
            _db.Sessions.Update(session);
            await _db.SaveChangesAsync();
            return session.Id;
        }


    }
}
