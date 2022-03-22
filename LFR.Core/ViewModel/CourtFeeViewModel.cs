using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Core.ViewModel
{
    public class CourtFeeViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string CurrencyType { get; set; }
        public DateTime DateCourtFee { get; set; }
        public string PayFor { get; set; }
    }
}
