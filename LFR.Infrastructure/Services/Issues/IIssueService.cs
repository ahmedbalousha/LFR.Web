using LFR.Core.Dtos;
using LFR.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Infrastructure.Services.Issues
{
  public interface IIssueService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Delete(int Id);
        IssueViewModel GetIssueByIssueNumber(int id);
        Task<List<UserViewModel>> GetIssueClients();
        Task<int> Create(CreateIssueDto dto);
        Task<UpdateIssueDto> Get(int id);
        Task<int> Update(UpdateIssueDto dto);
        Task<List<IssueViewModel>> GetIssueList();
    }
}
