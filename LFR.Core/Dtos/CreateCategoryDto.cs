using LFR.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Core.Dtos
{
    public class CreateCategoryDto
    {
        [Required]
        [Display(Name = "اسم التصنيف")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "نوع التصنيف")]
        public CategoryType CategoryType { get; set; }

    }
}
