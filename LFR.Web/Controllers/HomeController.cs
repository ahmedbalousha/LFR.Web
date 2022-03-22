using LFR.Core.Enums;
using LFR.Infrastructure.Services;
using LFR.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LFR.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IDashboardService _dashboardService;

        public HomeController(IDashboardService dashboardService, IUserService userService) : base(userService)
        {
            _dashboardService = dashboardService;
        }


        public async Task<IActionResult> Index()
        {
            //if (UserType != "Adminstrator")
            //{
            //    return Redirect("/category");
            //}
            var data = await _dashboardService.GetData();
            return View(data);
        }


        public async Task<IActionResult> GetUserTypeChartData()
        {
            var data = await _dashboardService.GetUserTypeChart();
            return Ok(data);
        }

        public async Task<IActionResult> GetContentTypeChartData()
        {
            var data = await _dashboardService.GetContentTypeChart();
            return Ok(data);
        }

        public async Task<IActionResult> GetContentByMonthChartData()
        {
            var data = await _dashboardService.GetContentByMonthChart();
            return Ok(data);
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}

    }
}
