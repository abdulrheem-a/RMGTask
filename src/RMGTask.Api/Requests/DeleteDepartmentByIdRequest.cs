using MediatR;

namespace RMGTask.Api.Requests
{
    public class DeleteDepartmentByIdRequest : IRequest
    {
        public int Id { get; set; }
    }
}
