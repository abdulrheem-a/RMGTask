using RMGTask.Api.Requests;
using RMGTask.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace RMGTask.Api.Application.Commands
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeRequest>
    {
        private readonly IEmployeeService _employeeService;

        public UpdateEmployeeCommandHandler(IEmployeeService EmployeeService)
        {
            _employeeService = EmployeeService;
        }

        public async Task<Unit> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            await _employeeService.UpdateEmployee(request.Employee);

            return Unit.Value;
        }
    }
}
