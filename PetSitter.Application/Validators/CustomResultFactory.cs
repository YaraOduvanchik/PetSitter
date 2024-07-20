using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PetSitter.Domain.Common;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;

namespace PetSitter.Application.Validators;

public class CustomResultFactory : IFluentValidationAutoValidationResultFactory
{
    public IActionResult CreateActionResult(
        ActionExecutingContext context,
        ValidationProblemDetails? validationProblemDetails)
    {
        if (validationProblemDetails is null)
            return new BadRequestObjectResult("Invalid error");

        var validationError = validationProblemDetails.Errors.First();
        var errorString = validationError.Value.First();

        if (!string.IsNullOrWhiteSpace(errorString))
            return new BadRequestObjectResult(Errors.General.ValueIsRequired());
        
        var error = Error.Deserialize(errorString);
        var envelope = Envelope.Error(error);

        return new BadRequestObjectResult(envelope);
    }
}