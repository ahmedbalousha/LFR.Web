using LFR.Core.Dtos;
using LFR.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Infrastructure.Services.Categories
{
    public interface ICategoryService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);

        Task<int> Create(CreateCategoryDto dto);

        Task<int> Update(UpdateCategoryDto dto);

        Task<UpdateCategoryDto> Get(int Id);
        
        Task<List<CategoryViewModel>> GetCategoryList();

        Task<int> Delete(int id);
        Task<List<CategoryViewModel>> GetAllAPI(string serachKey);
    }
}
