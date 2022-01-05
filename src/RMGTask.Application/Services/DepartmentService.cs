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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IAppLogger<DepartmentService> _logger;

        public DepartmentService(IDepartmentRepository departmentRepository, IAppLogger<DepartmentService> logger)
        {
            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<DepartmentModel>> GetDepartmentList()
        {
            var DepartmentList = await _departmentRepository.ListAllAsync();

            var DepartmentModels = ObjectMapper.Mapper.Map<IEnumerable<DepartmentModel>>(DepartmentList);

            return DepartmentModels;
        }

        public async Task<DepartmentModel> GetDepartmentById(int departmentId)
        {
            var department = await _departmentRepository.GetByIdAsync(departmentId);

            var departmentModel = ObjectMapper.Mapper.Map<DepartmentModel>(department);

            return departmentModel;
        }

        public async Task<DepartmentModel> CreateDepartment(DepartmentModel department)
        {
            var existingDepartment = await _departmentRepository.GetByIdAsync(department.Id);
            if (existingDepartment != null)
            {
                throw new ApplicationException("Department with this id already exists");
            }

            var newDepartment = ObjectMapper.Mapper.Map<Department>(department);
            newDepartment = await _departmentRepository.SaveAsync(newDepartment);

            _logger.LogInformation("Entity successfully added - RMGTaskAppService");

            var newDepartmentModel = ObjectMapper.Mapper.Map<DepartmentModel>(newDepartment);
            return newDepartmentModel;
        }

        public async Task UpdateDepartment(DepartmentModel department)
        {
            var existingDepartment = await _departmentRepository.GetByIdAsync(department.Id);
            if (existingDepartment == null)
            {
                throw new ApplicationException("Department with this id is not exists");
            }

            existingDepartment.Name = department.Name;
 

            await _departmentRepository.SaveAsync(existingDepartment);

            _logger.LogInformation("Entity successfully updated - RMGTaskAppService");
        }

        public async Task DeleteDepartmentById(int departmentId)
        {
            var existingDepartment = await _departmentRepository.GetByIdAsync(departmentId);
            if (existingDepartment == null)
            {
                throw new ApplicationException("Department with this id is not exists");
            }

            await _departmentRepository.DeleteAsync(existingDepartment);

            _logger.LogInformation("Entity successfully deleted - RMGTaskAppService");
        }
    }
}
