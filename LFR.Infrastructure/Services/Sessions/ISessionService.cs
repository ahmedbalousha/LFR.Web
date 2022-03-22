using LFR.Core.Dtos;
using LFR.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Infrastructure.Services.Sessions
{
    public interface ISessionService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);

        Task<int> Create(CreateSessionDto dto);

        Task<int> Update(UpdateSessionDto dto);

        Task<UpdateSessionDto> Get(int Id);
        

        Task<int> Delete(int Id);
        
    }
}
