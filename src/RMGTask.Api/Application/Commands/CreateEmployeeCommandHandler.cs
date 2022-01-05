using System.Threading;
using System.Threading.Tasks;
using RMGTask.Api.Requests;
using RMGTask.Application.Interfaces;
using RMGTask.Application.Models;
using MediatR;

namespace RMGTask.Api.Application.Commands
{
    public class CreateEmployeeCommandHandler
    : IRequestHandler<CreateEmployeeRequest, EmployeeModel>
    {
        private readonly IEmployeeService _employeeService;

        public CreateEmployeeCommandHandler(IEmployeeService EmployeeService)
        {
            _employeeService = EmployeeService;
        }

        public async Task<EmployeeModel> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employeeModel = await _employeeService.CreateEmployee(request.Employee);

            return employeeModel;
        }
    }
}
