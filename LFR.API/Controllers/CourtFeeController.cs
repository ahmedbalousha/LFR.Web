using LFR.API.Controllers;
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

        public CourtFeeController(ICourtFeeService courtFeeService, IUserService userService) : base(userService)
        {
            _courtFeeService = courtFeeService;
        }

      

        


        [HttpPost]
        public async Task<IActionResult> Create(CreateCourtFeeDto dto)
        {
            
             await  _courtFeeService.Create(dto);
                
            return Ok(GetResponse(dto));
        }

        

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCourtFeeDto dto)
        {
            if (ModelState.IsValid)
            {
                await  _courtFeeService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return Ok(GetResponse(dto));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await  _courtFeeService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }

    }
}
