using Genocs.BlazorClean.Template.Application.Interfaces.Repositories;
using Genocs.BlazorClean.Template.Application.Interfaces.Services;
using Genocs.BlazorClean.Template.Domain.Contracts;
using Genocs.BlazorClean.Template.Infrastructure.Contexts;
using LazyCache;
using System.Collections;

namespace Genocs.BlazorClean.Template.Infrastructure.Repositories;

public class ExtendedAttributeUnitOfWork<TId, TEntityId, TEntity> : IExtendedAttributeUnitOfWork<TId, TEntityId, TEntity> where TEntity : AuditableEntity<TEntityId>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly BlazorPortalContext _dbContext;
    private bool _disposed;
    private Hashtable _repositories;
    private readonly IAppCache _cache;

    public ExtendedAttributeUnitOfWork(BlazorPortalContext dbContext, ICurrentUserService currentUserService, IAppCache cache)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _currentUserService = currentUserService;
        _cache = cache;
    }

    public IRepositoryAsync<T, TId> Repository<T>() where T : AuditableEntityExtendedAttribute<TId, TEntityId, TEntity>
    {
        if (_repositories == null)
            _repositories = new Hashtable();

        string type = typeof(T).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(RepositoryAsync<,>);

            object repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T), typeof(TId)), _dbContext);

            _repositories.Add(type, repositoryInstance);
        }

        return (IRepositoryAsync<T, TId>)_repositories[type];
    }

    public async Task<int> Commit(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> CommitAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys)
    {
        int result = await _dbContext.SaveChangesAsync(cancellationToken);
        foreach (string cacheKey in cacheKeys)
        {
            _cache.Remove(cacheKey);
        }
        return result;
    }

    public Task Rollback()
    {
        _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                //dispose managed resources
                _dbContext.Dispose();
            }
        }
        //dispose unmanaged resources
        _disposed = true;
    }
}