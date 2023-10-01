using CSharpFunctionalExtensions;
using MediatR;

namespace CosmetiSafe.Web.Abstractions;

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>> where TCommand : ICommand<TResponse>
{
    
}