using LFR.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Data.Models
{
   public class Issue : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string IssueNumber { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public string IssueClientId { get; set; }
        public User IssueClient { get; set; }
        public string OpponentName { get; set; }
        public TypesOfIssues TypesOfIssues { get; set; }
        public List<CourtRequest> CourtRequests { get; set; }
        public List<Session> Sessions { get; set; }
        public int? LawyerChargeId { get; set; }
        public LawyerCharge LawyerCharge { get; set; }
        public DegreeOfLitigation DegreeOfLitigation { get; set; }
        public CourtType CourtType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Result { get; set; }

    }
}
