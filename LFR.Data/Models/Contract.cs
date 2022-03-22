using LFR.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Data.Models
{
    public class Contract : BaseEntity
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public string FirstParty { get; set; }
        public string FirstPartyAdjective { get; set; }
        [Required]
        public string SecondParty { get; set; }
        public string SecondPartyAdjective { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? LawyerChargeId { get; set; }
        public LawyerCharge LawyerCharge { get; set; }
        public string ImageUrl { get; set; }


    }
}
