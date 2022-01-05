using MediatR;

namespace RMGTask.Api.Requests
{
    public class DeleteEmployeeByIdRequest : IRequest
    {
        public int Id { get; set; }
    }
}
