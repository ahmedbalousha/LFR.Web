using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Core.Dtos
{
    public class UpdateCourtRequestDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "نوع الطلب")]
        public string Type { get; set; }
        [Required]
        [Display(Name = "تاريخ الطلب")]
        public DateTime DateCourtRequest { get; set; }
        [Display(Name = " صورة الطلب ")]
        public IFormFile Image { get; set; }
        //[Required]
        //[Display(Name = "اسم التصنيف")]
        //public CreateCourtFeeDto CourtFee { get; set; }
        //public string IssueId { get; set; }
        //public Issue Issue { get; set; }
    }
}
