using LFR.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LFR.Web.Data
{
    public class LFRDbContext : IdentityDbContext<User>
    {
        public LFRDbContext(DbContextOptions<LFRDbContext> options)
            : base(options)
        {
        }
       


        public DbSet<Issue> Issues { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<CourtFee> CourtFees { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<LawyerCharge> LawyerCharges { get; set; }
        public DbSet<CourtRequest> CourtRequests { get; set; }
        public DbSet<Category> Categories { get; set; }



    }
}
