using CarWashEF.Data;
using CarWashEF.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using CarWashEF.Repository;
using System.Windows.Forms;
using CarWashEF.dto;

namespace CarWashEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(UserRepository.GetUserCount());
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
