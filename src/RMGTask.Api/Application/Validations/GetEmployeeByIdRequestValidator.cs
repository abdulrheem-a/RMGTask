using RMGTask.Api.Requests;
using FluentValidation;

namespace RMGTask.Api.Application.Validations
{
    public class GetEmployeeByIdRequestValidator : AbstractValidator<GetEmployeeByIdRequest>
    {
        public GetEmployeeByIdRequestValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}
