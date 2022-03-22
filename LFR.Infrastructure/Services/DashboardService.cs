using LFR.Core.Enums;
using LFR.Core.ViewModel;
using LFR.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Infrastructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly LFRDbContext _db;

        public DashboardService(LFRDbContext db)
        {
            _db = db;
        }

        public async Task<DashboardViewModel> GetData()
        {
            var data = new DashboardViewModel();
            data.NumberOfUsers = await _db.Users.CountAsync(x => !x.IsDelete);
            data.NumberOfIssue = await _db.Issues.CountAsync(x => !x.IsDelete);
            data.NumberOfLawyerCharge = await _db.LawyerCharges.CountAsync(x => !x.IsDelete);
            data.NumberOfContract = await _db.Contracts.CountAsync(x => !x.IsDelete);
            return data;
        }

        public async Task<List<PieChartViewModel>> GetUserTypeChart()
        {

            var data = new List<PieChartViewModel>();
            data.Add(new PieChartViewModel()
            {
                Key = "Administrator",
                Value = await _db.Users.CountAsync(x => !x.IsDelete && x.UserType == UserType.Adminstrator),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Issue Client",
                Value = await _db.Users.CountAsync(x => !x.IsDelete && x.UserType == UserType.IssueClient),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Contract Client",
                Value = await _db.Users.CountAsync(x => !x.IsDelete && x.UserType == UserType.ContractClient),
                color = GenrateColor()
            });
            //data.Add(new PieChartViewModel()
            //{
            //    Key = "Advertisement Owner",
            //    Value = await _db.Users.CountAsync(x => !x.IsDelete && x.UserType == UserType.AdvertisementOwner),
            //    color = GenrateColor()
            //});
            return data;
        }


        public async Task<List<PieChartViewModel>> GetContentTypeChart()
        {

            var data = new List<PieChartViewModel>();
            data.Add(new PieChartViewModel()
            {
                Key = "Contract",
                Value = await _db.Contracts.CountAsync(x => !x.IsDelete),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Issue",
                Value = await _db.Issues.CountAsync(x => !x.IsDelete),
                color = GenrateColor()
            });
          
            return data;
        }


        public async Task<List<PieChartViewModel>> GetContentByMonthChart()
        {

            var data = new List<PieChartViewModel>();
            data.Add(new PieChartViewModel()
            {
                Key = "Jan",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 1).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Feb",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 2).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Mar",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 3).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Apr",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 4).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "May",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 5).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Jun",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 6).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Jul",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 7).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Aug",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 8).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Sep",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 9).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Oct",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 10).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Nov",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 11).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Dec",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 12).Count(),
                color = GenrateColor()
            });

            return data;
        }


        private string GenrateColor()
        {
            var random = new Random();
            return String.Format("#{0:X6}", random.Next(0x1000000));
        }
 
    }
}
