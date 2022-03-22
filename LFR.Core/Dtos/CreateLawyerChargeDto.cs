using LFR.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Core.Dtos
{
  public  class CreateLawyerChargeDto
    {
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "العدد ")]
        public int Number { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "نوع العملة ")]
        public CurrencyType CurrencyType { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "المدفوع ")]
        public int Payed { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "تاريخ الدفع ")]
        public DateTime CreatedAt { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "الدفع ل ")]
        public string PayFor { get; set; }
       
    }
}
