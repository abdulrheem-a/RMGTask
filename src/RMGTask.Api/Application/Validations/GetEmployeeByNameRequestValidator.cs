using RMGTask.Api.Requests;
using FluentValidation;

namespace RMGTask.Api.Application.Validations
{
    public class GetEmployeeByNameRequestValidator : AbstractValidator<GetEmployeesByNameRequest>
    {
        public GetEmployeeByNameRequestValidator()
        {
            RuleFor(request => request.Name).NotNull();
        }
    }
}
