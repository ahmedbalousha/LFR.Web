using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Data.Models
{
   public class CourtRequest : BaseEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime DateCourtRequest { get; set; }
        public int CourtFeeId { get; set; }
        public CourtFee CourtFee { get; set; }
        public string IssueId { get; set; }
        public Issue Issue { get; set; }
        public string ImageUrl { get; set; }

    }
}
