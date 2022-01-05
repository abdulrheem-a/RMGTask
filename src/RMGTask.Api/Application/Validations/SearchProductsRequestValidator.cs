using RMGTask.Api.Requests;
using FluentValidation;

namespace RMGTask.Api.Application.Validations
{
    public class SearchSearchRequestValidator : AbstractValidator<SearchPageRequest>
    {
        public SearchSearchRequestValidator()
        {
            RuleFor(request => request.Args).NotNull();
            RuleFor(request => request.Args.PageIndex).GreaterThan(0);
            RuleFor(request => request.Args.PageSize).InclusiveBetween(10, 100);
        }
    }
}
