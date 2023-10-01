using System.Net;
using CosmetiSafe.Domain;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace CosmetiSafe.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public abstract class ApplicationController : ControllerBase
{
    protected new IActionResult Ok(object? result = null)
    {
        return new EnvelopeResult(Envelope.Ok(result), HttpStatusCode.OK);
    }

    protected IActionResult NotFound(Error error, string? invalidField = null)
    {
        return new EnvelopeResult(Envelope.Error(error, invalidField), HttpStatusCode.NotFound);
    }

    protected IActionResult Error(Error error, string? invalidField = null)
    {
        return new EnvelopeResult(Envelope.Error(error, invalidField), HttpStatusCode.BadRequest);
    }

    protected IActionResult FromResult<T>(Result<T, Error> result)
    {
        return result.IsSuccess ? Ok() : Error(result.Error);
    }
}