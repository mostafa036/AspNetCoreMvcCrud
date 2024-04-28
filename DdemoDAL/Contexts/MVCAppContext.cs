using DemoDAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDAL.Contexts
{
    public class MVCAppContext : IdentityDbContext<ApplicationUser>
    {
        public MVCAppContext(DbContextOptions<MVCAppContext> options ):base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseSqlServer("Server = DESKTOP-V48EG3I\\SQLEXPRESS; Datebase =MVCApp ; Trusted_Connection=true;");
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //public DbSet<ApplicationUser> Users { get; set; }
    }
}
