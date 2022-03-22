using LFR.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Data.Models
{
   public class CourtFee : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public DateTime DateCourtFee { get; set; }
        public string PayFor { get; set; }

    }
}
