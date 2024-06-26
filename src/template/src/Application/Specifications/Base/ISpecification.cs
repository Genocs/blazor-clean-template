using Genocs.BlazorClean.Template.Domain.Contracts;
using System.Linq.Expressions;

namespace Genocs.BlazorClean.Template.Application.Specifications.Base;

public interface ISpecification<T>
    where T : class, IEntity
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    List<string> IncludeStrings { get; }
}