using LFR.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Core.ViewModel
{
  public  class ContractViewModel
    {
        public int Id { get; set; }
        public CategoryViewModel Category { get; set; }
        public string ContractClientId { get; set; }
        public string FirstParty { get; set; }
        public string FirstPartyAdjective { get; set; }
        public string SecondParty { get; set; }
        public string SecondPartyAdjective { get; set; }
        public DateTime DateCreated { get; set; }
        public string ImageUrl { get; set; }
        public LawyerChargeViewModel LawyerCharge { get; set; }

    }
}
