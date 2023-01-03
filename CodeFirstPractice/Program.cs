    using System;
using System.Data.Entity;
using DevelopmentInfo.Entities;

namespace CodeFirstPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pod = new Pod()
            {
                Id = 0,
                Name = "First Pod",
                PodTemp = 145.9
            };


            Console.WriteLine("Hello World!");
        }

        public class PodDBContext: DbContext
        {
            public DbSet<Pod> Pods { get; set; }
        }

    }
}
