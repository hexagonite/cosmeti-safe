using CSharpFunctionalExtensions;
using MediatR;

namespace CosmetiSafe.Web.Abstractions;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}