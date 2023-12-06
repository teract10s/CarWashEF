using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashEF.Model
{
    [Table("orders_servants")]
    public class OrderServant
    {
        [Column("order_id")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Column("servant_id")]
        public int ServantId { get; set; }
        public Servant Servant { get; set; }

        public OrderServant () { }

        public OrderServant(Order order, Servant servant) 
        {
            Order = order;
            Servant = servant;
            OrderId = order.Id;
            ServantId = servant.Id;
        }
    }
}
