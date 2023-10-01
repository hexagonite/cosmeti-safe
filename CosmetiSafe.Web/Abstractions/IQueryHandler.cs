using CSharpFunctionalExtensions;
using MediatR;

namespace CosmetiSafe.Web.Abstractions;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
{
}