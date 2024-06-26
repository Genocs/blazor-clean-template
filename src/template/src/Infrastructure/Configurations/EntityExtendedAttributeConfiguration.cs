using Genocs.BlazorClean.Template.Application.Serialization.Options;
using Genocs.BlazorClean.Template.Application.Serialization.Serializers;
using Genocs.BlazorClean.Template.Domain.Contracts;
using Genocs.BlazorClean.Template.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace Genocs.BlazorClean.Template.Infrastructure.Configurations;

public class EntityExtendedAttributeConfiguration : IEntityTypeConfiguration<IEntityExtendedAttribute>
{
    public void Configure(EntityTypeBuilder<IEntityExtendedAttribute> builder)
    {
        // This Converter will perform the conversion to and from Json to the desired type
        builder
            .Property(e => e.Json)
            .HasJsonConversion(
                new SystemTextJsonSerializer(
                    new OptionsWrapper<SystemTextJsonOptions>(new SystemTextJsonOptions())));
    }
}