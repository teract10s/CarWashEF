using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashEF.Model
{
    [Table("own_orders_servants")]
    public class OwnOrderServant
    {
        [Column("own_order_id")]
        public int OwnOrderId { get; set; }
        public OwnOrder OwnOrder { get; set; }
        [Column("servant_id")]
        public int ServantId { get; set; }
        public Servant Servant { get; set; }

        public OwnOrderServant() { }

        public OwnOrderServant(OwnOrder ownOrder, Servant servant)
        {
            OwnOrder = ownOrder;
            Servant = servant;
            OwnOrderId = ownOrder.Id;
            ServantId = servant.Id;
        }
    }
}
