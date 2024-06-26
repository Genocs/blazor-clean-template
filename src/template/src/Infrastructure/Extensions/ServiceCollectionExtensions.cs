﻿using Genocs.BlazorClean.Template.Application.Interfaces.Repositories;
using Genocs.BlazorClean.Template.Application.Interfaces.Serialization.Serializers;
using Genocs.BlazorClean.Template.Application.Interfaces.Services.Storage;
using Genocs.BlazorClean.Template.Application.Interfaces.Services.Storage.Provider;
using Genocs.BlazorClean.Template.Application.Serialization.JsonConverters;
using Genocs.BlazorClean.Template.Application.Serialization.Options;
using Genocs.BlazorClean.Template.Application.Serialization.Serializers;
using Genocs.BlazorClean.Template.Infrastructure.Repositories;
using Genocs.BlazorClean.Template.Infrastructure.Services.Storage;
using Genocs.BlazorClean.Template.Infrastructure.Services.Storage.Provider;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Genocs.BlazorClean.Template.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureMappings(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddTransient(typeof(IRepositoryAsync<,>), typeof(RepositoryAsync<,>))
            .AddTransient<IProductRepository, ProductRepository>()
            .AddTransient<IBrandRepository, BrandRepository>()
            .AddTransient<IDocumentRepository, DocumentRepository>()
            .AddTransient<IDocumentTypeRepository, DocumentTypeRepository>()
            .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
    }

    public static IServiceCollection AddExtendedAttributesUnitOfWork(this IServiceCollection services)
    {
        return services
            .AddTransient(typeof(IExtendedAttributeUnitOfWork<,,>), typeof(ExtendedAttributeUnitOfWork<,,>));
    }

    public static IServiceCollection AddServerStorage(this IServiceCollection services)
        => services.AddServerStorage(null);

    public static IServiceCollection AddServerStorage(this IServiceCollection services, Action<SystemTextJsonOptions> configure)
    {
        return services
            .AddScoped<IJsonSerializer, SystemTextJsonSerializer>()
            .AddScoped<IStorageProvider, ServerStorageProvider>()
            .AddScoped<IServerStorageService, ServerStorageService>()
            .AddScoped<ISyncServerStorageService, ServerStorageService>()
            .Configure<SystemTextJsonOptions>(configureOptions =>
            {
                configure?.Invoke(configureOptions);
                if (!configureOptions.JsonSerializerOptions.Converters.Any(c => c.GetType() == typeof(TimespanJsonConverter)))
                    configureOptions.JsonSerializerOptions.Converters.Add(new TimespanJsonConverter());
            });
    }
}