using RMGTask.Api.Requests;
using FluentValidation;

namespace RMGTask.Api.Application.Validations
{
    public class GetEmployeesByCategoryIdRequestValidator : AbstractValidator<GetEmployeesByDepartmentIdRequest>
    {
        public GetEmployeesByCategoryIdRequestValidator()
        {
            RuleFor(request => request.DepartmentId).GreaterThan(0);
        }
    }
}
