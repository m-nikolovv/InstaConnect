using Microsoft.AspNetCore.Diagnostics;

namespace InstaConnect.Common.Presentation.Features.Exceptions.Helpers;

public sealed class ExceptionHandler : IExceptionHandler
{
	private readonly IApplicationProblemDetailsFactory _problemDetailsFactory;
	private readonly IApplicationProblemDetailsService _problemDetailsService;

	public ExceptionHandler(
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
		var problemDetails = _problemDetailsFactory.Create(exception);
		await _problemDetailsService.WriteAsync(httpContext, exception, problemDetails, cancellationToken);

		return true;
	}
}
