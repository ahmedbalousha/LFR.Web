using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Core.ViewModel
{
  public class CourtRequestViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime DateCourtRequest { get; set; }
        public CourtFeeViewModel CourtFee { get; set; }
        public IssueViewModel Issue { get; set; }
    }
}
