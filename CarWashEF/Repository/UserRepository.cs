using CarWash.exception;
using CarWashEF.Data;
using CarWashEF.dto;
using CarWashEF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
        
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public static List<User> UnionExample()
        {
            using (var dbContext = new AppDbContext())
            {
                IEnumerable<User> unionResult = dbContext.Users
                            .Union(dbContext.Users.Where(u => u.Points > 100));
                return new List<User>(unionResult);
            }
        }

        public static List<User> GetUserWithoutOrders()
        {
            using (var dbContext = new AppDbContext())
            {
                IEnumerable<User> usersWithoutOrders = dbContext.Users
                                              .Except(dbContext.Users.Where(u => u.Orders.Any()));
                return new List<User>(usersWithoutOrders);
            }
        }

        public static List<User> GetUserWithOrderAndMorePointsThen(int numberOfPoints)
        {

            using (var dbContext = new AppDbContext())
            {
                IEnumerable<User> usersWithOrder = dbContext.Users
                             .Where(u => u.Orders.Any())
                             .Intersect(dbContext.Users.Where(u => u.Points > numberOfPoints));
                return new List<User>(usersWithOrder);
            }
        }

        public static List<UserWithOrderDetailsDto> GetUsersWithLoadedOrder()
        {

            using (var dbContext = new AppDbContext())
            {
                IEnumerable<UserWithOrderDetailsDto> joinResult = from user in dbContext.Users
                                                         join order in dbContext.Orders on user.Id equals order.User.Id
                                                         select new UserWithOrderDetailsDto { Email = user.Email, OrderDetails = order.Description };
                return new List<UserWithOrderDetailsDto>(joinResult);
            }
        }

        public static List<string> GetDistinctPassword()
        {
            using (var dbContext = new AppDbContext())
            {
                IEnumerable<string> distinctPassword = dbContext.Users
                                                .Select(u => u.Password)
                                                .Distinct(); 
                return new List<string>(distinctPassword);
            }
        }

        public static List<GroupedPoint> GetInfoAboutPoints()
        {
            using (var dbContext = new AppDbContext())
            {
                IEnumerable<GroupedPoint> groupedPoints = from user in dbContext.Users
                                                          group user by user.Points into groupedUsers
                                                          select new GroupedPoint { NumberOfPoints = (int)groupedUsers.Key, Count = groupedUsers.Count() };
                return new List<GroupedPoint>(groupedPoints);
            }
        }

        public static float GetMaxNumberOfPoints()
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Users.Max(u => u.Points);
            }
        }

        public static List<User> GetUsersEagerExample()
        {
            using (var dbContext = new AppDbContext())
            {
                List<User> users = dbContext.Users.Include(u => u.Orders).ToList();
                return new List<User>(users);
            }
        }

        public static User GetNoTrackingUser(int userId)
        {
            using (var context = new AppDbContext())
            {
                return context.Users.AsNoTracking().FirstOrDefault(u => u.Id == userId);
            }
        }

        public static void SaveNoTrackingUser(User user)
        {
            user.Nickname = "New Nickname";
            using (var context = new AppDbContext())
            {
                context.Users.Attach(user);
                context.Entry(user).Property(u => u.Nickname).IsModified = true;
                context.SaveChanges();
            }
        }

        [Obsolete]
        public static void InsertUserProcedure(string nickname, string password, string email, float points)
        {
            using (var context = new AppDbContext())
            {
                context.Database.ExecuteSqlCommand("EXEC dbo.InsertUser '" + nickname + "', '" + password + "', '" + email + "', '" + points + "'");
            }
        }

        [Obsolete]
        public static int GetUserCount()
        {
            using (var context = new AppDbContext())
            {
                var result = context.Users.FromSql($"SELECT dbo.GetUserCount()").FirstOrDefault();
                //return result;

                return context.Users.Count();
            }
        }
    }
}
