using AutoMapper;
using Genocs.BlazorClean.Template.Application.Interfaces.Repositories;
using Genocs.BlazorClean.Template.Domain.Contracts;
using Genocs.BlazorClean.Template.Shared.Constants.Application;
using Genocs.BlazorClean.Template.Shared.Wrapper;
using LazyCache;
using MediatR;

namespace Genocs.BlazorClean.Template.Application.Features.ExtendedAttributes.Queries.GetAll;

public class GetAllExtendedAttributesQuery<TId, TEntityId, TEntity, TExtendedAttribute>
    : IRequest<Result<List<GetAllExtendedAttributesResponse<TId, TEntityId>>>>
        where TEntity : AuditableEntity<TEntityId>, IEntityWithExtendedAttributes<TExtendedAttribute>, IEntity<TEntityId>
        where TExtendedAttribute : AuditableEntityExtendedAttribute<TId, TEntityId, TEntity>, IEntity<TId>
        where TId : IEquatable<TId>
{
    public GetAllExtendedAttributesQuery()
    {
    }
}

internal class GetAllExtendedAttributesQueryHandler<TId, TEntityId, TEntity, TExtendedAttribute>
    : IRequestHandler<GetAllExtendedAttributesQuery<TId, TEntityId, TEntity, TExtendedAttribute>, Result<List<GetAllExtendedAttributesResponse<TId, TEntityId>>>>
        where TEntity : AuditableEntity<TEntityId>, IEntityWithExtendedAttributes<TExtendedAttribute>, IEntity<TEntityId>
        where TExtendedAttribute : AuditableEntityExtendedAttribute<TId, TEntityId, TEntity>, IEntity<TId>
        where TId : IEquatable<TId>
{
    private readonly IUnitOfWork<TId> _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAppCache _cache;

    public GetAllExtendedAttributesQueryHandler(IUnitOfWork<TId> unitOfWork, IMapper mapper, IAppCache cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cache;
    }

    public async Task<Result<List<GetAllExtendedAttributesResponse<TId, TEntityId>>>> Handle(GetAllExtendedAttributesQuery<TId, TEntityId, TEntity, TExtendedAttribute> request, CancellationToken cancellationToken)
    {
        Func<Task<List<TExtendedAttribute>>> getAllExtendedAttributes = () => _unitOfWork.Repository<TExtendedAttribute>().GetAllAsync();
        var extendedAttributeList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllEntityExtendedAttributesCacheKey(typeof(TEntity).Name), getAllExtendedAttributes);
        var mappedExtendedAttributes = _mapper.Map<List<GetAllExtendedAttributesResponse<TId, TEntityId>>>(extendedAttributeList);
        return await Result<List<GetAllExtendedAttributesResponse<TId, TEntityId>>>.SuccessAsync(mappedExtendedAttributes);
    }
}
