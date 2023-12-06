using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.exception
{
    public class WrongEmailException : System.Exception
    {
        public WrongEmailException()
        {
        }

        public WrongEmailException(string message) : base(message)
        {
        }

        public WrongEmailException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}
