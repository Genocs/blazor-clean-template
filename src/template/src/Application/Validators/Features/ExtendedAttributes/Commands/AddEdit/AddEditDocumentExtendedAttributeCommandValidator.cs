using Genocs.BlazorClean.Template.Domain.Entities.ExtendedAttributes;
using Genocs.BlazorClean.Template.Domain.Entities.Misc;
using Microsoft.Extensions.Localization;

namespace Genocs.BlazorClean.Template.Application.Validators.Features.ExtendedAttributes.Commands.AddEdit;

public class AddEditDocumentExtendedAttributeCommandValidator : AddEditExtendedAttributeCommandValidator<int, int, Document, DocumentExtendedAttribute>
{
    public AddEditDocumentExtendedAttributeCommandValidator(IStringLocalizer<AddEditExtendedAttributeCommandValidatorLocalization> localizer) : base(localizer)
    {
        // you can override the validation rules here
    }
}