using CarWashEF.Data;
using CarWashEF.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using CarWashEF.Repository;

namespace CarWashEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                User user = new User() { Id = 1, Nickname = "nick", Email = "trs@gmail.com", Password = "12345678" };
                User userFromDb = UserRepository.CreateUser(user);
                Console.WriteLine("Inserted user: " + userFromDb.ToString());
                Console.WriteLine("By email: " + UserRepository.GetByEmail(user.Email).ToString());
                UserRepository.DeleteById(userFromDb.Id);
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
