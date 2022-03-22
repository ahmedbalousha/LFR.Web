using LFR.Core.Constants;
using LFR.Core.Dtos;
using LFR.Infrastructure.Services.Categories;
using LFR.Infrastructure.Services.Contracts;
using LFR.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace LFR.Web.Controllers
{
    public class ContractController : BaseController
    {

        private readonly IContractService _contractService;
        private readonly ICategoryService _categoryService;

        public ContractController(IContractService contractService, IUserService userService , ICategoryService categoryService):base (userService)
        {
            _contractService = contractService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetContractData(Pagination pagination, Query query)
        {
            var result = await _contractService.GetAll(pagination, query);
            return Json(result);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["categories"] = new SelectList(await _categoryService.GetCategoryList(), "Id", "Name");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateContractDto dto)
        {
            
            if (ModelState.IsValid)
            {
                await _contractService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var contract = await _contractService.Get(id);
            ViewData["categories"] = new SelectList(await _categoryService.GetCategoryList(), "Id", "Name");

            return View(contract);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateContractDto dto)
        {
            if (ModelState.IsValid)
            {
                await _contractService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _contractService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }

        
    }
}
