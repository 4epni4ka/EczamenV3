using EczamenV3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EczamenV3.Context
{
    public class PlainsContext:DbContext
    {
        public DbSet<Plains> Plains { get; set; }
        public PlainsContext()
        {
            Database.EnsureCreated();
            Plains.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql("server=127.0.0.1;user=root;password=Asdfg123;database=avia", new MySqlServerVersion(new Version(8, 0, 11)));
    }
}
