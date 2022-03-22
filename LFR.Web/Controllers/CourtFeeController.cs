using LFR.Core.Constants;
using LFR.Core.Dtos;
using LFR.Infrastructure.Services.Categories;
using LFR.Infrastructure.Services.CourtFees;
using LFR.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LFR.Web.Controllers
{
    public class CourtFeeController : BaseController
    {

        private readonly ICourtFeeService _courtFeeService;

        public CourtFeeController(ICourtFeeService courtFeeService, IUserService userService) :base(userService)
        {
            _courtFeeService = courtFeeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetCourtFeeData(Pagination pagination,Query query)
        {
            var result = await  _courtFeeService.GetAll(pagination, query);
            return  Json(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourtFeeDto dto)
        {
            if (ModelState.IsValid)
            {
                await  _courtFeeService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await  _courtFeeService.Get(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCourtFeeDto dto)
        {
            if (ModelState.IsValid)
            {
                await  _courtFeeService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await  _courtFeeService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }

    }
}
