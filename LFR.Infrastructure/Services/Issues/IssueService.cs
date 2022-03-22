using AutoMapper;
using LFR.Core.Dtos;
using LFR.Core.Enums;
using LFR.Core.Exceptions;
using LFR.Core.ViewModel;
using LFR.Data.Models;
using LFR.Infrastructure.Services.CourtRequests;
using LFR.Infrastructure.Services.LawyerCharges;
using LFR.Infrastructure.Services.Users;
using LFR.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Infrastructure.Services.Issues
{
    public class IssueService : IIssueService
    {
        private readonly LFRDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILawyerChargeService _lawyerChargeService;
        private readonly IFileService _fileService;
        private readonly IUserService _userService;
        private readonly ICourtRequestService _courtRequestService;

        public IssueService(LFRDbContext db, IMapper mapper,
            ILawyerChargeService lawyerChargeService, IFileService fileService,
            IUserService userService, ICourtRequestService courtRequestService)
        {
            _db = db;
            _mapper = mapper;
            _lawyerChargeService = lawyerChargeService;
            _fileService = fileService;
            _userService = userService;
            _courtRequestService = courtRequestService;
        }

        public async Task<List<UserViewModel>> GetIssueClients()
        {
            var users = await _db.Users.Where(x => !x.IsDelete && x.UserType == UserType.IssueClient).ToListAsync();
            return _mapper.Map<List<UserViewModel>>(users);
        }
        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Issues
                .Include(x => x.Category)
                .Include(x => x.CourtRequests)
                .Include(x => x.IssueClient)
                .Where(x => !x.IsDelete && (x.IssueNumber.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var categories = _mapper.Map<List<IssueViewModel>>(dataList);
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
        public IssueViewModel GetIssueByIssueNumber(int id)
        {
            var issue = _db.Issues.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            if (issue == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<IssueViewModel>(issue);
        }
        public async Task<List<IssueViewModel>> GetIssueList()
        {
            var issues = await _db.Issues.Where(x => !x.IsDelete).ToListAsync();
            return _mapper.Map<List<IssueViewModel>>(issues);
        }
        public async Task<int> Delete(int Id)
        {
            var issue = await _db.Issues.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (issue == null)
            {
                throw new EntityNotFoundException();
            }
            issue.IsDelete = true;
            _db.Issues.Update(issue);
            await _db.SaveChangesAsync();
            return issue.Id;
        }

        public async Task<int> Create(CreateIssueDto dto)
        {
            var issue = _mapper.Map<Issue>(dto);
            
            await _db.Issues.AddAsync(issue);
            await _db.SaveChangesAsync();

            //if (issue.LawyerChargeId == null)
            //{
            //    var lawyerChargeId = await _lawyerChargeService.Create(dto.LawyerCharge);
            //    issue.LawyerChargeId = lawyerChargeId;

            //    _db.Issues.Update(issue);
            //    await _db.SaveChangesAsync();

            //}
            if (!string.IsNullOrWhiteSpace(dto.IssueClientId))
            {
                issue.IssueClientId = dto.IssueClientId;
            }
            if (issue.IssueClientId == null)
            {
                var issueClientId = await _userService.Create(dto.IssueClient);
                issue.IssueClientId = issueClientId;

                _db.Issues.Update(issue);
                await _db.SaveChangesAsync();

            }
            return issue.Id;
        }
        public async Task<UpdateIssueDto> Get(int id)
        {
            var issue = await _db.Issues.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (issue == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateIssueDto>(issue);
        }
        public async Task<int> Update(UpdateIssueDto dto)
        {

            var issue = await _db.Issues.SingleOrDefaultAsync(x => x.Id == dto.Id && !x.IsDelete);
            if (issue == null)
            {
                throw new EntityNotFoundException();
            }

            var updatedIssue = _mapper.Map(dto, issue);

           

            _db.Issues.Update(updatedIssue);
            await _db.SaveChangesAsync();

            return issue.Id;
        }

    }

}
