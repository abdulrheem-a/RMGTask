using System.Threading;
using System.Threading.Tasks;
using RMGTask.Api.Requests;
using RMGTask.Application.Interfaces;
using RMGTask.Application.Models;
using MediatR;

namespace RMGTask.Api.Application.Commands
{
    public class CreateDepartmentCommandHandler
: IRequestHandler<CreateDepartmentRequest, DepartmentModel>
    {
        private readonly IDepartmentService _departmentService;

        public CreateDepartmentCommandHandler(IDepartmentService DepartmentService)
        {
            _departmentService = DepartmentService;
        }

        public async Task<DepartmentModel> Handle(CreateDepartmentRequest request, CancellationToken cancellationToken)
        {
            var departmentModel = await _departmentService.CreateDepartment(request.Department);

            return departmentModel;
        }
    }
}
