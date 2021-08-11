using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.DataAccess
{
    public class HotelDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=SEFA; Database=HotelDb; uid=sa; pwd=1234;"); 
            // Server ismi SEFA, ve bu swdeki hangi database e bastıracağız -> HotelDb
            // yani migrattion kullanırken HotelDb diye bir database oluşturacak.
        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}
