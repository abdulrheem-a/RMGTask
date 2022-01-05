using RMGTask.Application.Models;
using MediatR;

namespace RMGTask.Api.Requests
{
    public class CreateEmployeeRequest : IRequest<EmployeeModel>
    {
        public EmployeeModel Employee { get; set; }
    }
}
