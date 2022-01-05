using RMGTask.Api.Requests;
using FluentValidation;

namespace RMGTask.Api.Application.Validations
{
    public class DeleteEmployeeRequestValidator : AbstractValidator<DeleteEmployeeByIdRequest>
    {
        public DeleteEmployeeRequestValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}
