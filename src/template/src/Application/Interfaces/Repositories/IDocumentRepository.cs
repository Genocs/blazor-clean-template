﻿namespace Genocs.BlazorClean.Template.Application.Interfaces.Repositories;

public interface IDocumentRepository
{
    Task<bool> IsDocumentTypeUsed(int documentTypeId);

    Task<bool> IsDocumentExtendedAttributeUsed(int documentExtendedAttributeId);
}