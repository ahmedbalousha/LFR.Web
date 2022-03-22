using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Data.Models
{
  public  class Session : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public DateTime? SessionDate { get; set; }
        public string SessionDecision { get; set; }
        public int IssueId { get; set; }
        public Issue Issue { get; set; }


    }
}
