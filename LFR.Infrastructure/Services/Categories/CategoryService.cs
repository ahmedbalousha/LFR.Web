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

namespace LFR.Infrastructure.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly LFRDbContext _db;
        private readonly IMapper _mapper;

        public CategoryService(LFRDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<List<CategoryViewModel>> GetCategoryList()
        {
            var categories = await _db.Categories.Where(x => !x.IsDelete ).ToListAsync();
            return _mapper.Map<List<CategoryViewModel>>(categories);
        }
        public async Task<List<CategoryViewModel>> GetAllAPI(string serachKey)
        {
            var categories = _db.Categories.Where(x => x.Name.Contains(serachKey) || string.IsNullOrWhiteSpace(serachKey)).Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            return categories;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Categories.Where(x => !x.IsDelete && (x.Name.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var categories = _mapper.Map<List<CategoryViewModel>>(dataList);
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


        public async Task<int> Create(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
             _db.Categories.Add(category);
             _db.SaveChanges();
            return category.Id;
        }


        public async Task<int> Update(UpdateCategoryDto dto)
        {
            var category =  _db.Categories.SingleOrDefault(x => !x.IsDelete && x.Id == dto.Id);
            if(category == null)
            {
                //throw new EntityNotFoundException();
            }
            var updatedCategory = _mapper.Map<UpdateCategoryDto, Category>(dto, category);
            _db.Categories.Update(updatedCategory);
            _db.SaveChanges();
            return updatedCategory.Id;
        }

        //
        public async Task<UpdateCategoryDto> Get(int Id)
        {
            var category = await _db.Categories.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (category == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateCategoryDto>(category);
        }


        public async Task<int> Delete(int id)
        {
            var category =  _db.Categories.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            if (category == null)
            {
                throw new EntityNotFoundException();
            }
            category.IsDelete = true;
            _db.Categories.Update(category);
            _db.SaveChanges();
            return category.Id;
        }
       

    }
}
