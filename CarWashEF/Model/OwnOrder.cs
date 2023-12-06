using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashEF.Model
{
    [Table("own_orders")]
    public class OwnOrder
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

        [Column("name")]
        public string Name { get; set; }

        public List<OwnOrderServant> Servants { get; set; } = new List<OwnOrderServant>();

        public OwnOrder() { }

        public OwnOrder(string description, int time, List<Servant> servants)
        {
            Description = description;
            Time = time;
            Servants = GenerateOrderServant(servants);
            ReferenceEquals(this, servants);
        }

        private List<OwnOrderServant> GenerateOrderServant(List<Servant> servants)
        {
            List<OwnOrderServant> ows = new List<OwnOrderServant>();
            foreach (var s in servants)
            {
                ows.Add(new OwnOrderServant(this, s));
            }
            return ows;
        }
    }
}
