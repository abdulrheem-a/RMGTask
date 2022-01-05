using RMGTask.Application.Models;
using MediatR;

namespace RMGTask.Api.Requests
{
    public class UpdateEmployeeRequest : IRequest
    {
        public EmployeeModel Employee { get; set; }
    }
}
