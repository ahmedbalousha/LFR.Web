using LFR.API.Controllers;
using LFR.Core.Constants;
using LFR.Core.Dtos;
using LFR.Infrastructure.Services.Categories;
using LFR.Infrastructure.Services.LawyerCharges;
using LFR.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LFR.Web.Controllers
{
    public class LawyerChargeController : BaseController
    {

        private readonly ILawyerChargeService _lawyerChargeService;

        public LawyerChargeController(ILawyerChargeService lawyerChargeService, IUserService userService) :base(userService)
        {
            _lawyerChargeService = lawyerChargeService;
        }

       
        [HttpPost]
        public async Task<IActionResult> Create(CreateLawyerChargeDto dto )
        {
            if (ModelState.IsValid)
            {
                await _lawyerChargeService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
                return View(dto);
            
        }

       

        [HttpPut]
        public async Task<IActionResult> Update(UpdateLawyerChargeDto dto)
        {
            if (ModelState.IsValid)
            {
                await _lawyerChargeService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _lawyerChargeService.Delete(Id);
            return Ok(Results.DeleteSuccessResult());
        }

    }
}
