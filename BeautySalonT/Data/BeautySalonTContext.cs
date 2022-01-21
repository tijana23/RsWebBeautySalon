using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeautySalonT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BeautySalonT.Areas.Identity.Data;

namespace BeautySalonT.Data
{
    public class BeautySalonTContext : IdentityDbContext<BeautySalonTUser>
    {
        public BeautySalonTContext (DbContextOptions<BeautySalonTContext> options)
            : base(options)
        {
        }

        public DbSet<BeautySalonT.Models.Appointment> Appointment { get; set; }

        public DbSet<BeautySalonT.Models.Employee> Employee { get; set; }

        public DbSet<BeautySalonT.Models.Service> Service { get; set; }

        public DbSet<BeautySalonT.Models.Client> Client { get; set; }
        public DbSet<EmployeeService> EmployeeService { get; set; }
        /*  protected override void OnModelCreating(ModelBuilder builder)
          {
              builder.Entity<EmployeeService>()
              .HasOne<Employee>(p => p.Employee)
              .WithMany(p => p.Services)
              .HasForeignKey(p => p.EmployeeId);
              //.HasPrincipalKey(p => p.Id);
              builder.Entity<EmployeeService>()
              .HasOne<Service>(p => p.Service)
              .WithMany(p => p.Employee)
              .HasForeignKey(p => p.ServiceId);
              //.HasPrincipalKey(p => p.Id);

          }*/
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


    }
}
