using System.Net;
using CosmetiSafe.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CosmetiSafe.Web;

public class ModelStateValidator
{
    public static IActionResult ValidateModelState(ActionContext context)
    {
        var (fieldName, entry) = context.ModelState.First(x => x.Value?.Errors.Count > 0);
        var errorSerialized = entry!.Errors.First().ErrorMessage;

        var error = Error.Deserialize(errorSerialized);
        var envelope = Envelope.Error(error, fieldName);
        var envelopeResult = new EnvelopeResult(envelope, HttpStatusCode.BadRequest);

        return envelopeResult;
    }
}