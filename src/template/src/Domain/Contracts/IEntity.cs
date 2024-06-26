namespace Genocs.BlazorClean.Template.Domain.Contracts;

public interface IEntity<TId> : IEntity
{
    public TId Id { get; set; }
}

public interface IEntity
{
}