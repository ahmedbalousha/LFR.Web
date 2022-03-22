using LFR.Core.ViewModel;
using LFR.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LFR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        protected readonly IUserService _userService;
        protected string userType;
        protected string userId;

        public BaseController(IUserService userService)
        {
            _userService = userService;
        }
        protected async Task<APIResponseViewModel> GetResponse(object data)
        {
            var response = new APIResponseViewModel(true, "Done", data);
            return response;
        }
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    base.OnActionExecuting(context);
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var userName = User.Identity.Name;
        //        var user = _userService.GetUserByUsername(userName);
        //        userId = user.Id;
        //        userType = user.UserType;
        //        ViewBag.fullName = user.FullName;
        //        ViewBag.image = user.ImageUrl;
        //        ViewBag.UserType = user.UserType.ToString();
        //    }
        //}

    }
}
