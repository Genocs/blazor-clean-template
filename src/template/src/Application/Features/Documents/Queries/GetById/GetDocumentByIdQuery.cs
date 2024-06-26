using AutoMapper;
using Genocs.BlazorClean.Template.Application.Interfaces.Repositories;
using Genocs.BlazorClean.Template.Domain.Entities.Misc;
using Genocs.BlazorClean.Template.Shared.Wrapper;
using MediatR;

namespace Genocs.BlazorClean.Template.Application.Features.Documents.Queries.GetById;

public class GetDocumentByIdQuery : IRequest<Result<GetDocumentByIdResponse>>
{
    public int Id { get; set; }
}

internal class GetDocumentByIdQueryHandler : IRequestHandler<GetDocumentByIdQuery, Result<GetDocumentByIdResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;
    private readonly IMapper _mapper;

    public GetDocumentByIdQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<GetDocumentByIdResponse>> Handle(GetDocumentByIdQuery query, CancellationToken cancellationToken)
    {
        var document = await _unitOfWork.Repository<Document>().GetByIdAsync(query.Id);
        var mappedDocument = _mapper.Map<GetDocumentByIdResponse>(document);
        return await Result<GetDocumentByIdResponse>.SuccessAsync(mappedDocument);
    }
}