using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWashEF.Model
{
    [Table("servants")]
    public class Servant
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public float Price { get; set; }

        [Column("servant_type", TypeName = "nvarchar(50)")]
        public ServantType ServantType { get; set; }

        [Column("time")]
        public int Time { get; set; }

        public List<OrderServant> Orders { get; set; } = new List<OrderServant>();

        public List<OwnOrder> OwnOrders { get; set; }

        public Servant() { }

        public Servant(string name, float price, int time, ServantType servantType)
        {
            Name = name;
            Price = price;
            Time = time;
            ServantType = servantType;
        }
    }

    public enum ServantType
    {
        WASH,
        POLISHING,
        DRY_CLEANERS
    }
}
