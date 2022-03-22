using LFR.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Infrastructure.Services.CourtFees
{
   public interface ICourtFeeService
    {
         Task<ResponseDto> GetAll(Pagination pagination, Query query);
         Task<int> Create(CreateCourtFeeDto dto);
         Task<int> Update(UpdateCourtFeeDto dto);
         Task<UpdateCourtFeeDto> Get(int Id);
         Task<int> Delete(int Id);

    }
}
