using LFR.Core.Constants;
using LFR.Core.Dtos;
using LFR.Infrastructure.Services.Categories;
using LFR.Infrastructure.Services.Issues;
using LFR.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LFR.Web.Controllers
{
    public class IssueController : BaseController
    {

        private readonly IIssueService _issueService;
        private readonly ICategoryService _categoryService;

        public IssueController(IIssueService issueService, IUserService userService, ICategoryService categoryService) : base(userService)
        {
            _issueService = issueService;
            _categoryService = categoryService;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
       
        public async Task<JsonResult> GetIssueData(Pagination pagination,Query query)
        {
            var result = await _issueService.GetAll(pagination, query);
            return  Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["IssueClient"] = new SelectList(await _issueService.GetIssueClients(), "Id", "FullName");
            ViewData["categories"] = new SelectList(await _categoryService.GetCategoryList(), "Id", "Name");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateIssueDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.IssueClientId))
            {
                ModelState.Remove("IssueClient.FullName");
                ModelState.Remove("IssueClient.Email");
                ModelState.Remove("IssueClient.PhoneNumber");
            }

            if (ModelState.IsValid)
            {
                await _issueService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
        }

      

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var user = await _issueService.Get(id);
            ViewData["categories"] = new SelectList(await _categoryService.GetCategoryList(), "Id", "Name");
            ViewData["IssueClient"] = new SelectList(await _issueService.GetIssueClients(), "Id", "FullName");

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateIssueDto dto)
        {
            if (ModelState.IsValid)
            {
                await _issueService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
           _issueService.GetIssueByIssueNumber(id);
            return View  ();
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _issueService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }

    }
}
