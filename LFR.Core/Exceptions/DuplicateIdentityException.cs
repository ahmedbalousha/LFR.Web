using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Core.Exceptions
{
   public class DuplicateIdentityException : Exception
    {
        public DuplicateIdentityException(): base("Duplicate Identity Exception")
        {

        }
    }
}
