using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.exception
{
    public class InsertEntityException : System.Exception
    {
        public InsertEntityException()
        {
        }

        public InsertEntityException(string message) : base(message)
        {
        }

        public InsertEntityException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}
