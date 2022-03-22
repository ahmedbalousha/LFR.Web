using LFR.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Core.Dtos
{
   public class UpdateCourtFeeDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "الرسوم بالعدد")]
        public int Number { get; set; }
        [Required]
        [Display(Name = "نوع العملة")]
        public CurrencyType CurrencyType { get; set; }
        [Required]
        [Display(Name = "تاريخ دفع الرسوم")]
        public DateTime? DateCourtFee { get; set; }
        [Required]
        [Display(Name = "الجهة المدفوع لها الرسوم")]
        public string PayFor { get; set; }
    }
}
