using LFR.Core.Enums;
using LFR.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Core.ViewModel
{
    public class IssueViewModel
    {
        public int Id { get; set; }
        public string IssueNumber { get; set; }
        public CategoryViewModel Category { get; set; }
        public UserViewModel IssueClient { get; set; }
        public string OpponentName { get; set; }
        public List<CourtRequestViewModel> CourtRequests { get; set; }
        public List<SessionViewModel> Sessions { get; set; }
        public LawyerChargeViewModel LawyerCharge { get; set; }
        public DegreeOfLitigation DegreeOfLitigation { get; set; }
        public CourtType CourtType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Result { get; set; }

    }
}
