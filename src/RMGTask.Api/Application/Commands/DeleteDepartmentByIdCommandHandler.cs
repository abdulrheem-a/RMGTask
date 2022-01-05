using System.Threading;
using System.Threading.Tasks;
using RMGTask.Api.Requests;
using RMGTask.Application.Interfaces;
using MediatR;

namespace RMGTask.Api.Application.Commands
{
    public class DeleteDepartmentByIdCommandHandler : IRequestHandler<DeleteDepartmentByIdRequest>
    {
        private readonly IDepartmentService _departmentService;

        public DeleteDepartmentByIdCommandHandler(IDepartmentService DepartmentService)
        {
            _departmentService = DepartmentService;
        }

        public async Task<Unit> Handle(DeleteDepartmentByIdRequest request, CancellationToken cancellationToken)
        {
            await _departmentService.DeleteDepartmentById(request.Id);

            return Unit.Value;
        }
    }

}
