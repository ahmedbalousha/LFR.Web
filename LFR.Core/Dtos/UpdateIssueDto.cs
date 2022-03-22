using LFR.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Core.Dtos
{
    public class UpdateIssueDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "رقم القضة ")]
        public string IssueNumber { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "التصنيف ")]
        public int? CategoryId { get; set; }
        [Display(Name = "اسم الموكل ")]
        public string IssueClientId { get; set; }
        public CreateUserDto IssueClient { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "اسم الخصم ")]
        public string OpponentName { get; set; }
        public TypesOfIssues TypesOfIssues { get; set; }
        //public CreateLawyerChargeDto LawyerCharge { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "درجة التقاضي ")]
        public DegreeOfLitigation DegreeOfLitigation { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "نوع المحكمة ")]
        public CourtType CourtType { get; set; }
        [Display(Name = "تاريخ التوكل بالقضية ")]
        public DateTime StartDate { get; set; }
        [Display(Name = "تاريخ إنتهاء القضية ")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "نتيجة القضية ")]
        public string Result { get; set; }

    }
}
