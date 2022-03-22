using LFR.Core.Constants;
using LFR.Core.Dtos;
using LFR.Infrastructure.Services.Issues;
using LFR.Infrastructure.Services.Sessions;
using LFR.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LFR.Web.Controllers
{
    public class SessionController : BaseController
    {

        private readonly ISessionService _sessionService;
        private readonly IIssueService _issueService;


        public SessionController(ISessionService sessionService, IUserService userService, IIssueService issueService) :base(userService) 
        {
            _sessionService = sessionService;
            _issueService = issueService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetSessionData(Pagination pagination,Query query)
        {
            var result = await _sessionService.GetAll(pagination, query);
            return  Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["issues"] = new SelectList(await _issueService.GetIssueList(), "Id", "IssueNumber");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSessionDto dto)
        {
            //ViewData["issues"] = new SelectList(await _issueService.GetIssueList(), "Id", "IssueNumber");
            if (ModelState.IsValid)
            {
                await _sessionService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _sessionService.Get(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSessionDto dto)
        {
            if (ModelState.IsValid)
            {
                await _sessionService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _sessionService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }

    }
}
