using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Core.Dtos
{
    public class CreateSessionDto
    {
        [Required]
        [Display(Name = "تاريخ الجلسة")]
        public DateTime? SessionDate { get; set; }
        [Required]
        [Display(Name = "قرار الجلسة")]
        public string SessionDecision { get; set; }
        [Display(Name = "القضية ")]
        public int IssueId { get; set; }
    }
}
