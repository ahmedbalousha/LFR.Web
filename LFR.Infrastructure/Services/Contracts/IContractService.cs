using LFR.Core.Dtos;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Infrastructure.Services.Contracts
{
 public interface IContractService
    {
        Task<int> Create(CreateContractDto dto);
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Delete(int id);
        Task<int> Update(UpdateContractDto dto);
        Task<UpdateContractDto> Get(int Id);
    }
}
