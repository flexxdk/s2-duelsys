using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validation.Exceptions
{
    public class NoValidContestantsException : Exception
    {
        public NoValidContestantsException() { }

        public NoValidContestantsException(string message)
            : base(message)
        { }
    }
}
