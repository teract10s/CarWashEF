using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashEF.Model
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("time")]
        public int Time { get; set; }

        [Column("price")]
        public float Price { get; set; }

        [Column("date_time")]
        public DateTime DateTime { get; set; }

        [Column("user_id")]
        public User User { get; set; }

        public List<OrderServant> Servants { get; set; } = new List<OrderServant>();

        public Order() { }

        public Order(string description, int time, User user, List<Servant> servants) 
        {
            Description = description;
            Time = time;
            User = user;
            DateTime = DateTime.Now;
            Servants = GenerateOrderServant(servants);
            ReferenceEquals(this, servants);
        }

        private List<OrderServant> GenerateOrderServant(List<Servant> servants)
        {
            List<OrderServant> os = new List<OrderServant>();
            foreach (var s in servants)
            {
                os.Add(new OrderServant(this, s));
            }
            return os;
        }
    }
}
