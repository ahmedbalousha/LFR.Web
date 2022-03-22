using LFR.Core.Enums;
using LFR.Infrastructure.Services;
using LFR.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LFR.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return Ok("Wellcom to api");
            return Redirect("/swagger");
        }
    }
}
