using LFR.Core.Dtos;
using LFR.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Infrastructure.Services.LawyerCharges
{
    public interface ILawyerChargeService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);

        Task<int> Create(CreateLawyerChargeDto dto);

        Task<int> Update(UpdateLawyerChargeDto dto);

        Task<UpdateLawyerChargeDto> Get(int Id);

        //Task<List<CategoryViewModel>> GetCategoryList();

        Task<int> Delete(int id);
    }
}
