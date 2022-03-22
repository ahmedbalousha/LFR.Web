using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Core.Dtos
{
    public class CreateCourtRequestDto
    {
        [Required]
        [Display(Name = "نوع الطلب")]
        public string Type { get; set; }
        [Required]
        [Display(Name = "تاريخ الطلب")]
        public DateTime DateCourtRequest { get; set; }
        [Required]
        [Display(Name = "اسم التصنيف")]
        public CreateCourtFeeDto CourtFee { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = " صورة الطلب ")]
        public IFormFile Image { get; set; }
        [Display(Name = "القضية ")]
        public int IssueId { get; set; }
    }
}
