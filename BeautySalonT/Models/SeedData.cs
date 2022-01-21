using BeautySalonT.Areas.Identity.Data;
using BeautySalonT.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautySalonT.Models
{
    public class SeedData
    {
        public static async Task CreateUserRole(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<BeautySalonTUser>>();
            IdentityResult roleResult;

            //Add Admin Role

            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck) { roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin")); }

            BeautySalonTUser user = await UserManager.FindByEmailAsync("admin@beautysalont.com");
            if (user == null)
            {
                var User = new BeautySalonTUser();
                User.Email = "admin@beautysalont.com";
                User.UserName = "admin@beautysalont.com";
                string userPWD = "Admin123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                //Add default User to Role Admin
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Admin"); }
            }

            roleCheck = await RoleManager.RoleExistsAsync("Employee");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Employee"));
            }
            user = await UserManager.FindByEmailAsync("marijam@beautysalont.com");
            if (user == null)
            {
                var User = new BeautySalonTUser();
                User.Email = "marijam@beautysalont.com";
                User.UserName = "marijam@beautysalont.com";
                User.EmployeeId = 1;
                string userPWD = "Marija123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Employee"); }
            }

            //Add Client Role
            roleCheck = await RoleManager.RoleExistsAsync("Client");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Client"));
            }

            user = await UserManager.FindByEmailAsync("tijanan@beautysalont.com");
            if (user == null)
            {
                var User = new BeautySalonTUser();
                User.Email = "tijanan@beautysalont.com";
                User.UserName = "tijanan@beautysalont.com";
                User.ClientId = 1;
                string userPWD = "Tijana123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Client"); }
            }


        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BeautySalonTContext(serviceProvider.GetRequiredService<DbContextOptions<BeautySalonTContext>>()))
            {
                CreateUserRole(serviceProvider).Wait();


                if (context.Client.Any() || context.Service.Any() || context.Employee.Any())
                {
                    return;
                }
                context.Client.AddRange(
                    new Client
                    {
                        FirstName = "Tijana",
                        LastName = "Nastevska",
                        TelephoneNumber = 077526325

                    },
                    new Client
                    {
                        FirstName = "Nadica",
                        LastName = "Trajkovska",
                        TelephoneNumber = 075687798

                    },
                    new Client
                    {
                        FirstName = "Marija",
                        LastName = "Malevska",
                        TelephoneNumber = 077526325

                    }

                );
                context.SaveChanges();

                context.Service.AddRange(
                    new Service
                    {
                        Title = "Blow Dry",
                        Duration = "15 minutes",
                        Price = "40$"
                    },
                    new Service
                    {
                        Title = "Basic Tint",
                        Duration = "12 minutes",
                        Price = "65$"
                    },
                    new Service
                    {
                        Title = "Perms",
                        Duration = "45 minutes",
                        Price = "100$"
                    }
                );
                context.SaveChanges();

                context.Employee.AddRange(
                    new Employee
                    {
                        FirstName = "Marina",
                        LastName = "Mladenovska",
                        SSN = "2108988455631",
                        Licence = "Yes",
                        OfficeNumber = 2775343,
                        HireDate = DateTime.Parse("2019-1-01")
                    },
                    new Employee
                    {
                        FirstName = "Angela",
                        LastName = "Martinovska",
                        SSN = "0306997455032",
                        Licence = "Yes",
                        OfficeNumber = 2775342,
                        HireDate = DateTime.Parse("2020-5-06")
                    },
                    new Employee
                    {
                        FirstName = "Nikolina",
                        LastName = "Trajkova",
                        SSN = "1504993455021",
                        Licence = "Yes",
                        OfficeNumber = 2775341,
                        HireDate = DateTime.Parse("2018-9-04")
                    }
                );
                context.SaveChanges();

                context.Appointment.AddRange(
                    new Appointment
                    {

                        ServiceId = context.Service.Single(t => t.Title == "Blow Dry").Id,
                        ClientId = context.Client.Single(t => t.FirstName == "Tijana" && t.LastName == "Nastevska").Id,
                        Time = "15:00",
                        Date = DateTime.Parse("2021-9-02"),
                    },
                    new Appointment
                    {

                        ServiceId = context.Service.Single(t => t.Title == "Basic Tint").Id,
                        ClientId = context.Client.Single(t => t.FirstName == "Nadica" && t.LastName == "Trajkovska").Id,
                        Time = "12:45",
                        Date = DateTime.Parse("2021-9-02"),
                    },
                    new Appointment
                    {

                        ServiceId = context.Service.Single(t => t.Title == "Perms").Id,
                        ClientId = context.Client.Single(t => t.FirstName == "Marija" && t.LastName == "Malevska").Id,
                        Time = "11:30",
                        Date = DateTime.Parse("2021-9-02"),
                    }

                );
                context.SaveChanges();
                context.EmployeeService.AddRange
                    (
                new EmployeeService { EmployeeId = 1, ServiceId = 2 },
                new EmployeeService { EmployeeId = 3, ServiceId = 1 },
                new EmployeeService { EmployeeId = 2, ServiceId = 3 }
                    );
                context.SaveChanges();

            }
        }

        private static object CreateUserRoles(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }
    }
}
