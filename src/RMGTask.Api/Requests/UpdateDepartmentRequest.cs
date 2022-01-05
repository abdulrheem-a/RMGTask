using RMGTask.Application.Models;
using MediatR;

namespace RMGTask.Api.Requests
{
    public class UpdateDepartmentRequest : IRequest
    {
        public DepartmentModel Department { get; set; }
    }
}
