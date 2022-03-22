using LFR.Infrastructure.Services;
using LFR.Infrastructure.Services.Categories;
using LFR.Infrastructure.Services.Contracts;
using LFR.Infrastructure.Services.CourtFees;
using LFR.Infrastructure.Services.CourtRequests;
using LFR.Infrastructure.Services.Issues;
using LFR.Infrastructure.Services.LawyerCharges;
using LFR.Infrastructure.Services.Sessions;
using LFR.Infrastructure.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Infrastructure.Extentions
{
    public static class ServiceContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<ILawyerChargeService, LawyerChargeService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICourtFeeService, CourtFeeService>();
            services.AddTransient<ISessionService, SessionService>();
            services.AddTransient<IContractService, ContractService>();
            services.AddTransient<ICourtRequestService, CourtRequestService>();
            services.AddTransient<IIssueService, IssueService>();
            services.AddTransient<IDashboardService, DashboardService>();

            return services;
        }
    }
}
