using Microsoft.AspNetCore.Diagnostics;

namespace InstaConnect.Common.Presentation.Features.Exceptions.Helpers;

public sealed class InvalidValidationExceptionHandler : IExceptionHandler
{
	private readonly IApplicationProblemDetailsFactory _problemDetailsFactory;
	private readonly IApplicationProblemDetailsService _problemDetailsService;

	public InvalidValidationExceptionHandler(
		IApplicationProblemDetailsFactory problemDetailsFactory,
		IApplicationProblemDetailsService problemDetailsService)
	{
		_problemDetailsFactory = problemDetailsFactory;
		_problemDetailsService = problemDetailsService;
	}

	public async ValueTask<bool> TryHandleAsync(
		HttpContext httpContext,
		Exception exception,
		CancellationToken cancellationToken)
	{
		if (exception is not InvalidValidationException invalidValidationException)
		{
			return false;
		}

		var problemDetails = _problemDetailsFactory.Create(invalidValidationException);
		await _problemDetailsService.WriteAsync(httpContext, invalidValidationException, problemDetails, cancellationToken);

		return true;
	}
}
