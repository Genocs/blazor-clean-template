﻿using Genocs.BlazorClean.Template.Application.Features.DocumentTypes.Commands.AddEdit;
using Genocs.BlazorClean.Template.Application.Features.DocumentTypes.Queries.GetAll;
using Genocs.BlazorClean.Template.Shared.Wrapper;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Misc.DocumentType;

public interface IDocumentTypeManager : IManager
{
    Task<IResult<List<GetAllDocumentTypesResponse>>> GetAllAsync();

    Task<IResult<int>> SaveAsync(AddEditDocumentTypeCommand request);

    Task<IResult<int>> DeleteAsync(int id);

    Task<IResult<string>> ExportToExcelAsync(string searchString = "");
}