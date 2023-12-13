using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashEF.dto
{
    public class UserWithOrderDetailsDto
    {
        public string Email { get; set; }
        public string OrderDetails { get; set; }

        public string ToString()
        {
            return "User-order:"
                + "\n\t email: " + Email
                + "\n\t order details: " + OrderDetails;
        }
    }
}
