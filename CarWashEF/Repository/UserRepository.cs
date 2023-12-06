using CarWash.exception;
using CarWashEF.Data;
using CarWashEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashEF.Repository
{
    public static class UserRepository
    {
        public static List<User> GetAll()
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Users.ToList();
            }
        }

        public static User GetById (int id)
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Users.Where(u => u.Id == id).First();
            }
        }

        public static User GetByEmail(string email)
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Users.Where(u => u.Email.Equals(email)).FirstOrDefault();
            }
        }

        public static User CreateUser (User user)
        {
            if (GetByEmail(user.Email) != null)
                throw new InsertEntityException("We have user with such email");
            using (var dbContext = new AppDbContext())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return GetByEmail(user.Email);
            }
        }

        public static void DeleteById(int id)
        {
            var userFromDb = GetById(id);
            using (var dbContext = new AppDbContext())
            {
                dbContext.Users.Remove(userFromDb);
                dbContext.SaveChanges();
            }
        }
    }
}
