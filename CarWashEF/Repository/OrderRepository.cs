﻿using CarWashEF.Data;
using CarWashEF.Model;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace CarWashEF.Repository
{
    public class OrderRepository
    {
        public static List<Order> GetAll()
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Orders.ToList();
            }
        }

        public static Order GetById(int id)
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Orders.Where(o => o.Id == id).First();
            }
        }

        public static List<Order> GetByUserId(int userId)
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Orders.Where(s => s.User.Id.Equals(userId)).ToList();
            }
        }

        public static void CreateOrder(Order order)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Orders.Add(order);
                dbContext.SaveChanges();
            }
        }

        public static void DeleteById(int id)
        {
            var orderFromDb = GetById(id);
            using (var dbContext = new AppDbContext())
            {
                dbContext.Orders.Remove(orderFromDb);
                dbContext.SaveChanges();
            }
        }

        public static List<Order> GetByUserIdExample(int userId)
        {
            using (var dbContext = new AppDbContext())
            {
                var user = dbContext.Users.Find(userId);

                dbContext.Entry(user)
                       .Collection(u => u.Orders)
                       .Load();

                return user.Orders.ToList();
            }
        }
    }
}
