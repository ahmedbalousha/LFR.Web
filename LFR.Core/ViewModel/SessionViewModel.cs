using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Core.ViewModel
{
  public class SessionViewModel
    {
        public int Id { get; set; }
        public DateTime SessionDate { get; set; }
        public string SessionDecision { get; set; }
        public IssueViewModel Issue { get; set; }
    }
}
