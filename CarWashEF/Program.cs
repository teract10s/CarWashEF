using System;
using System.Diagnostics;
using CarWashEF.Data;
using CarWashEF.Multithreading;

namespace CarWashEF
{
    public class Program
    {
        static void Main(string[] args)
        {
            long startTimeStamp = Stopwatch.GetTimestamp();
            for (int i = 0; i < 10; i++)
            {
                var user = UserGenerator.GenerateUser("usual");
                using (var context = new AppDbContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            long endTimeStamp = Stopwatch.GetTimestamp();
            Console.WriteLine("Time (without threads): " + (endTimeStamp - startTimeStamp));
            Console.WriteLine("Clasic(without threads) usage task completed successfully...\n");

            TPLUsage.GenerateAndReadUsers();
            ClassicUsage.GenerateAndReadUsers();
            Console.WriteLine("Tasks completed successfully.");
        }
    }
}
