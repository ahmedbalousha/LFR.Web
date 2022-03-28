using LFR.Core.Constants;
using LFR.Core.Dtos;
using LFR.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LFR.API.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IUserService userService):base(userService)
        {
        }
        
        [HttpGet]
        public ActionResult GetAllAPI(string serachkey)
        {
            var users = _userService.GetAllAPI(serachkey);
            return Ok(GetResponse(users));
        }

        [HttpGet]
        public IActionResult GetAPI(string id)
        {
            var user = _userService.GetAPI(id);
            return Ok(GetResponse(user));
        }
        [HttpPost]
        public IActionResult Create(CreateUserDto dto)
        {
            var savedId = _userService.Create(dto);
            return Ok(GetResponse(savedId));
        }

        [HttpPut]
        public IActionResult Update(UpdateUserDto dto)
        {
            var savedId = _userService.Update(dto);
            return Ok(GetResponse(savedId));
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
           var deletedId =  _userService.Delete(id);
            return Ok(GetResponse(deletedId));
        }
    }
}
