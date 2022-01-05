using RMGTask.Api.Requests;
using FluentValidation;

namespace RMGTask.Api.Application.Validations
{
    public class CreateEmployeeRequestValidator : AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeRequestValidator()
        {
            RuleFor(request => request.Employee).NotNull();
        }
    }

}
