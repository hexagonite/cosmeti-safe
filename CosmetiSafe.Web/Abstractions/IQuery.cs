using CSharpFunctionalExtensions;
using MediatR;

namespace CosmetiSafe.Web.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}