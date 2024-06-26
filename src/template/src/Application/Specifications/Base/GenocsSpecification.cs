using Genocs.BlazorClean.Template.Domain.Contracts;
using System.Linq.Expressions;

namespace Genocs.BlazorClean.Template.Application.Specifications.Base;

public abstract class GenocsSpecification<T> : ISpecification<T>
    where T : class, IEntity
{
    public Expression<Func<T, bool>> Criteria { get; set; }
    public List<Expression<Func<T, object>>> Includes { get; } = new();
    public List<string> IncludeStrings { get; } = new();

    protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected virtual void AddInclude(string includeString)
    {
        IncludeStrings.Add(includeString);
    }
}