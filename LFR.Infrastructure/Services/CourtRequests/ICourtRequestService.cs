using LFR.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Infrastructure.Services.CourtRequests
{
   public interface ICourtRequestService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Create(CreateCourtRequestDto dto);
        Task<int> Delete(int Id);
        Task<UpdateCourtRequestDto> Get(int Id);
        Task<int> Update(UpdateCourtRequestDto dto);
    }
}
