namespace InstaConnect.Common.Presentation.Features.Exceptions.Helpers;

public class ApplicationProblemDetailsService : IApplicationProblemDetailsService
{
	private readonly IProblemDetailsService _problemDetailsService;

	public ApplicationProblemDetailsService(IProblemDetailsService problemDetailsService)
	{
		_problemDetailsService = problemDetailsService;
	}

	public async Task WriteAsync(
		HttpContext httpContext,
		Exception exception,
		ApplicationProblemDetails details,
		CancellationToken cancellationToken)
	{
		httpContext.Response.StatusCode = details.Status ?? StatusCodes.Status500InternalServerError;

		var problemDetailsContext = new ProblemDetailsContext
		{
			HttpContext = httpContext,
			Exception = exception,
			ProblemDetails = details,
		};

		await _problemDetailsService.TryWriteAsync(problemDetailsContext);
	}
}
