using AutoMapper;
using Genocs.BlazorClean.Template.Application.Interfaces.Repositories;
using Genocs.BlazorClean.Template.Domain.Entities.Misc;
using Genocs.BlazorClean.Template.Shared.Wrapper;
using MediatR;

namespace Genocs.BlazorClean.Template.Application.Features.DocumentTypes.Queries.GetById;

public class GetDocumentTypeByIdQuery : IRequest<Result<GetDocumentTypeByIdResponse>>
{
    public int Id { get; set; }
}

internal class GetDocumentTypeByIdQueryHandler : IRequestHandler<GetDocumentTypeByIdQuery, Result<GetDocumentTypeByIdResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;
    private readonly IMapper _mapper;

    public GetDocumentTypeByIdQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<GetDocumentTypeByIdResponse>> Handle(GetDocumentTypeByIdQuery query, CancellationToken cancellationToken)
    {
        var documentType = await _unitOfWork.Repository<DocumentType>().GetByIdAsync(query.Id);
        var mappedDocumentType = _mapper.Map<GetDocumentTypeByIdResponse>(documentType);
        return await Result<GetDocumentTypeByIdResponse>.SuccessAsync(mappedDocumentType);
    }
}