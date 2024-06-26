using FluentValidation;
using Genocs.BlazorClean.Template.Application.Requests.Identity;
using Microsoft.Extensions.Localization;

namespace Genocs.BlazorClean.Template.Application.Validators.Requests.Identity;

public class ForgotPasswordRequestValidator : AbstractValidator<ForgotPasswordRequest>
{
    public ForgotPasswordRequestValidator(IStringLocalizer<ForgotPasswordRequestValidator> localizer)
    {
        RuleFor(request => request.Email)
            .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["Email is required"])
            .EmailAddress().WithMessage(x => localizer["Email is not correct"]);
    }
}