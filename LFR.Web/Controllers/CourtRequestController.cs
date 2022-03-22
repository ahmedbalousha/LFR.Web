using LFR.Core.Constants;
using LFR.Core.Dtos;
using LFR.Infrastructure.Services.CourtRequests;
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
    public class CourtRequestController : BaseController
    {

        private readonly ICourtRequestService _courtRequestService;
        private readonly IIssueService _issueService;
        public CourtRequestController(ICourtRequestService courtRequestService, IUserService userService, IIssueService issueService) :base(userService) 
        {
            _courtRequestService = courtRequestService;
            _issueService = issueService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetCourtRequestData(Pagination pagination,Query query)
        {
            var result = await  _courtRequestService.GetAll(pagination, query);
            return  Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["issues"] = new SelectList(await _issueService.GetIssueList(), "Id", "IssueNumber");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourtRequestDto dto)
        {
            if (ModelState.IsValid)
            {
                await  _courtRequestService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _courtRequestService.Get(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCourtRequestDto dto)
        {
            if (ModelState.IsValid)
            {
                await _courtRequestService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await  _courtRequestService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }

    }
}
