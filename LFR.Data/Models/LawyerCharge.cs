using LFR.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Data.Models
{
   public class LawyerCharge : BaseEntity
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public int Payed { get; set; }
        public DateTime DateCharge { get; set; }
        public string PayFor { get; set; }
        public List<Issue> Issues { get; set; }
        public List<Contract> Contracts { get; set; }
        public LawyerCharge()
        {
            Residual = Number - Payed;
        }
        public int Residual { get; set; }


    }
}
