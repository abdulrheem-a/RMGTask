using RMGTask.Application.Models;
using MediatR;

namespace RMGTask.Api.Requests
{
    public class CreateDepartmentRequest : IRequest<DepartmentModel>
    {
        public DepartmentModel Department { get; set; }
    }
}
