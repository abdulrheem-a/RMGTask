using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RMGTask.Application.Interfaces;
using RMGTask.Application.Mapper;
using RMGTask.Application.Models;
using RMGTask.Core.Entities;
using RMGTask.Core.Interfaces;
using RMGTask.Core.Paging;
using RMGTask.Core.Repositories;
using RMGTask.Core.Specifications;
using RMGTask.Infrastructure.Paging;

namespace RMGTask.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAppLogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository employeeRepository, IAppLogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeeList()
        {
            var employeeList = await _employeeRepository.ListAllAsync();

            var employeeModels = ObjectMapper.Mapper.Map<IEnumerable<EmployeeModel>>(employeeList);

            return employeeModels;
        }

        public async Task<IPagedList<EmployeeModel>> SearchEmployee(PageSearchArgs args)
        {
            var employeePagedList = await _employeeRepository.SearchEmployeesAsync(args);

            //TODO: PagedList<TSource> will be mapped to PagedList<TDestination>;
            var employeeModels = ObjectMapper.Mapper.Map<List<EmployeeModel>>(employeePagedList.Items);

            var employeeModelPagedList = new PagedList<EmployeeModel>(
                employeePagedList.PageIndex,
                employeePagedList.PageSize,
                employeePagedList.TotalCount,
                employeePagedList.TotalPages,
                employeeModels);

            return employeeModelPagedList;
        }

        public async Task<EmployeeModel> GetEmployeeById(int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);

            var employeeModel = ObjectMapper.Mapper.Map<EmployeeModel>(employee);

            return employeeModel;
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeesByName(string name)
        {
            var spec = new EmployeeWithDepartmentSpecification(name);
            var employeeList = await _employeeRepository.GetAsync(spec);

            var employeeModels = ObjectMapper.Mapper.Map<IEnumerable<EmployeeModel>>(employeeList);

            return employeeModels;
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeesByDepartmentId(int DepartmentId)
        {
            var spec = new EmployeeWithDepartmentSpecification(DepartmentId);
            var employeeList = await _employeeRepository.GetAsync(spec);

            var employeeModels = ObjectMapper.Mapper.Map<IEnumerable<EmployeeModel>>(employeeList);

            return employeeModels;
        }

        public async Task<EmployeeModel> CreateEmployee(EmployeeModel employee)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(employee.Id);
            if (existingEmployee != null)
            {
                throw new ApplicationException("Employee with this id already exists");
            }

            var newEmployee = ObjectMapper.Mapper.Map<Employee>(employee);
            newEmployee = await _employeeRepository.SaveAsync(newEmployee);

            _logger.LogInformation("Entity successfully added - RMGTaskAppService");

            var newEmployeeModel = ObjectMapper.Mapper.Map<EmployeeModel>(newEmployee);
            return newEmployeeModel;
        }

        public async Task UpdateEmployee(EmployeeModel employee)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(employee.Id);
            if (existingEmployee == null)
            {
                throw new ApplicationException("Employee with this id is not exists");
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.DepartmentId = employee.DepartmentId;

            await _employeeRepository.SaveAsync(existingEmployee);

            _logger.LogInformation("Entity successfully updated - RMGTaskAppService");
        }

        public async Task DeleteEmployeeById(int employeeId)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(employeeId);
            if (existingEmployee == null)
            {
                throw new ApplicationException("Employee with this id is not exists");
            }

            await _employeeRepository.DeleteAsync(existingEmployee);

            _logger.LogInformation("Entity successfully deleted - RMGTaskAppService");
        }
    }
}
