using RMGTask.Core.Entities;
using RMGTask.Core.Repositories;
using RMGTask.Core.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMGTask.Infrastructure.Data
{
    public class RMGTaskContextSeed
    {
        private readonly RMGTaskContext _RMGTaskContext;
        private readonly UserManager<RMGTaskUser> _userManager;

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public RMGTaskContextSeed(
            RMGTaskContext RMGTaskContext,
            UserManager<RMGTaskUser> userManager,
            IEmployeeRepository employeeRepository,
        IDepartmentRepository departmentRepository)
        {
            _RMGTaskContext = RMGTaskContext;
            _userManager = userManager;
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task SeedAsync()
        {
            // TODO: Only run this if using a real database
            // _RMGTaskContext.Database.Migrate();
            // _RMGTaskContext.Database.EnsureCreated();

            //deparyment
            await SeedDepartmentAsync();

            // Employee
            await SeedEmployeeAsync();

            // users
            await SeedUsersAsync();
        }

        private async Task SeedDepartmentAsync()
        {
            if (!_departmentRepository.Table.Any())
            {
                var departments = new List<Department>
                {
                    new Department() { Name = "IT"}, // 1
                    new Department() { Name = "HR"}, // 2
                    new Department() { Name = "Accounting"}, // 3
                };

                await _departmentRepository.AddRangeAsync(departments);
            }
        }

        private async Task SeedEmployeeAsync()
        {
            if (!_employeeRepository.Table.Any())
            {
                var employees = new List<Employee>
                {
                    // IT
                    new Employee()
                    {
                        Name = "Patrick moboma",
                        Salary=2000,
                        Department = _departmentRepository.Table.FirstOrDefault(c => c.Name == "IT")
                    },
                    new Employee()
                    {
                        Name = "Mohammed Salah",
                        Salary=2000,
                        Department = _departmentRepository.Table.FirstOrDefault(c => c.Name == "IT")
                    },
                    new Employee()
                    {
                        Name = "Isac Neoton",
                        Salary=2000,
                        Department = _departmentRepository.Table.FirstOrDefault(c => c.Name == "IT")
                    },
                    new Employee()
                    {
                        Name = "Bell Gates",
                        Salary=2000,
                        Department = _departmentRepository.Table.FirstOrDefault(c => c.Name == "IT")

                    },
                    // HR                
                    new Employee()
                    {
                        Name = "Bella Haddid",
                        Salary=2000,
                        Department = _departmentRepository.Table.FirstOrDefault(c => c.Name == "HR")
                    },
                    new Employee()
                    {
                        Name = "Bella Haddid",
                        Salary=2000,
                        Department = _departmentRepository.Table.FirstOrDefault(c => c.Name == "IT")
                    },
                    new Employee()
                    {
                        Name = "Mini Mouse",
                        Salary=2000,
                        Department = _departmentRepository.Table.FirstOrDefault(c => c.Name == "HR")
                    },
                    new Employee()
                    {
                        Name = "Anne hathaway",
                        Salary=2000,
                        Department = _departmentRepository.Table.FirstOrDefault(c => c.Name == "HR")
                    },
                    // Accounting
                   new Employee()
                    {
                        Name = "Elon Mask",
                        Salary=2000,
                        Department = _departmentRepository.Table.FirstOrDefault(c => c.Name == "Accounting")
                    },
                };

                await _employeeRepository.AddRangeAsync(employees);

            }
        }


        private async Task SeedUsersAsync()
        {
            var user = await _userManager.FindByEmailAsync("rmguser@rmg.com");
            if (user == null)
            {
                user = new RMGTaskUser
                {
                    FirstName = "RMG",
                    LastName = "User",
                    Email = "rmguser@rmg.com",
                    UserName = "RMGUser"
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create user in Seeding");
                }

                _RMGTaskContext.Entry(user).State = EntityState.Unchanged;
            }
        }
    }
}
