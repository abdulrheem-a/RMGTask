using System.Threading;
using System.Threading.Tasks;
using RMGTask.Api.Requests;
using RMGTask.Application.Interfaces;
using MediatR;

namespace RMGTask.Api.Application.Commands
{
    public class DeleteEmployeeByIdCommandHandler : IRequestHandler<DeleteEmployeeByIdRequest>
    {
        private readonly IEmployeeService _employeeService;

        public DeleteEmployeeByIdCommandHandler(IEmployeeService EmployeeService)
        {
            _employeeService = EmployeeService;
        }

        public async Task<Unit> Handle(DeleteEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            await _employeeService.DeleteEmployeeById(request.Id);

            return Unit.Value;
        }
    }

}
