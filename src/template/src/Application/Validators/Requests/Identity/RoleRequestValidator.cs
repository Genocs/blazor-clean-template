using FluentValidation;
using Genocs.BlazorClean.Template.Application.Requests.Identity;
using Microsoft.Extensions.Localization;

namespace Genocs.BlazorClean.Template.Application.Validators.Requests.Identity;

public class RoleRequestValidator : AbstractValidator<RoleRequest>
{
    public RoleRequestValidator(IStringLocalizer<RoleRequestValidator> localizer)
    {
        RuleFor(request => request.Name)
            .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["Name is required"]);
    }
}
