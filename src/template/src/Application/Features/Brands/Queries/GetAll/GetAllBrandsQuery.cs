using AutoMapper;
using Genocs.BlazorClean.Template.Application.Interfaces.Repositories;
using Genocs.BlazorClean.Template.Domain.Entities.Catalog;
using Genocs.BlazorClean.Template.Shared.Constants.Application;
using Genocs.BlazorClean.Template.Shared.Wrapper;
using LazyCache;
using MediatR;

namespace Genocs.BlazorClean.Template.Application.Features.Brands.Queries.GetAll;

public class GetAllBrandsQuery : IRequest<Result<List<GetAllBrandsResponse>>>
{
    public GetAllBrandsQuery()
    {
    }
}

internal class GetAllBrandsCachedQueryHandler : IRequestHandler<GetAllBrandsQuery, Result<List<GetAllBrandsResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAppCache _cache;

    public GetAllBrandsCachedQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IAppCache cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cache;
    }

    public async Task<Result<List<GetAllBrandsResponse>>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        Func<Task<List<Brand>>> getAllBrands = () => _unitOfWork.Repository<Brand>().GetAllAsync();
        var brandList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllBrandsCacheKey, getAllBrands);
        var mappedBrands = _mapper.Map<List<GetAllBrandsResponse>>(brandList);
        return await Result<List<GetAllBrandsResponse>>.SuccessAsync(mappedBrands);
    }
}