using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ServicesLibrary.Models;

namespace ServicesLibrary.Helpers
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        
        public DbSet<LocalDto> Locals { get; set; }
        public DbSet<ServiceDto> Services { get; set; }
        public DbSet<StoreDto> Stores { get; set; }
        public DbSet<BusinessDto> Business { get; set; }
        public DbSet<CityDto> Cities { get; set; }
    }
}

