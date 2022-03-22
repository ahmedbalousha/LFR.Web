using LFR.Core.Dtos;
using LFR.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Infrastructure.Services.Users
{
  public  interface IUserService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<string> Create(CreateUserDto dto);
        Task<UpdateUserDto> Get(string Id);
        Task<string> Update(UpdateUserDto dto);
        Task<string> Delete(string Id);
        UserViewModel GetUserByUsername(string username);
        Task<UserViewModel> GetAPI(string id);
        Task<List<UserViewModel>> GetAllAPI(string serachKey);
        Task<byte[]> ExportToExcel();
    }
}
