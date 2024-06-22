using EczamenV3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EczamenV3.Context
{
    public class ReisesContext:DbContext
    {
        public DbSet<Reises> Reises { get; set; }
        public ReisesContext()
        {
            Database.EnsureCreated();
            Reises.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql("server=127.0.0.1;user=root;password=Asdfg123;database=avia", new MySqlServerVersion(new Version(8, 0, 11)));
    }
}
