using CarWash.exception;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarWashEF.Model
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("nickname")]
        public string Nickname { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("email")]
        public string Email {  get; set; }

        [Column("points")]
        public float Points {  get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

        public User() { }

        public User(string nickname, string password, string email, int points)
        {
            Nickname = nickname;
            Password = password;
            Points = points;

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                Email = email;
            }
            else
            {
                throw new WrongEmailException(email + " not true email");
            }
        }

        public User(string nickname, string password, string email)
        {
            Nickname = nickname;
            Password = password;
            Points = 0;

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                this.Email = email;
            }
            else
            {
                throw new WrongEmailException(email + " not true email");
            }
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Id: ");
            sb.AppendLine(Id.ToString());
            sb.Append("email: ");
            sb.AppendLine(Email);
            sb.Append("nickname: ");
            sb.AppendLine(Nickname);
            sb.Append("password: ");
            sb.AppendLine(Password);
            return sb.ToString();
        }
    }
}
