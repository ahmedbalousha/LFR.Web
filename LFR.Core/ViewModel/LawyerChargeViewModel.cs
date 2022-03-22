using LFR.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Core.ViewModel
{
    public class LawyerChargeViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string CurrencyType { get; set; }
        public int Payed { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PayFor { get; set; }
        public int Residual { get; set; }
        



    }
}
