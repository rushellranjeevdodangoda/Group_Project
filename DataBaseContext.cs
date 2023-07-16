using Group_Project.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    public class DataBaseContext:DbContext
    {
        private readonly string path = @"C:\Users\rushe\OneDrive\Desktop\Group_Project\Group_Project\database.db";

        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={path}");

        public DbSet<Student> Students { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Result> Results { get; set; }


    }
}
