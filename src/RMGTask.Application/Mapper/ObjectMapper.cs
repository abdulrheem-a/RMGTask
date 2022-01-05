using RMGTask.Application.Models;
using RMGTask.Core.Entities;
using AutoMapper;

namespace RMGTask.Application.Mapper
{
    public class ObjectMapper
    {
        public static IMapper Mapper => AutoMapper.Mapper.Instance;

        static ObjectMapper()
        {
            CreateMap();
        }

        private static void CreateMap()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Department, DepartmentModel>().ReverseMap();
                cfg.CreateMap<Employee, EmployeeModel>().ReverseMap();
            });
        }
    }
}
