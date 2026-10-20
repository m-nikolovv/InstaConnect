namespace InstaConnect.Common.Presentation.Features.Exceptions.Helpers;

public class ApplicationProblemDetailsFactory : IApplicationProblemDetailsFactory
{
	private readonly IEnumerable<IBaseExceptionStatus> _exceptionStatuses;

	public ApplicationProblemDetailsFactory(IEnumerable<IBaseExceptionStatus> exceptionStatuses)
	{
		_exceptionStatuses = exceptionStatuses;
	}

	public ApplicationProblemDetails Create(BaseException exception)
	{
		var exceptionStatus = _exceptionStatuses.First(a => a.Status == exception.Status);

		return exceptionStatus.GetApplicationProblemDetails(exception);
	}

	public ApplicationProblemDetails Create(Exception exception)
	{
		var problemDetails = new ApplicationProblemDetails
		{
			Status = StatusCodes.Status500InternalServerError,
			Type = exception.GetType().Name,
			Title = exception.GetType().Name,
			Detail = exception.InnerException?.Message ?? exception.Message
		};

		return problemDetails;
	}

	public ApplicationProblemDetails Create(InvalidValidationException exception)
	{
		var problemDetails = new ApplicationProblemDetails
		{
			Status = StatusCodes.Status400BadRequest,
			Type = exception.GetType().Name,
			Title = exception.GetType().Name,
			Detail = exception.InnerException?.Message ?? exception.Message,
			Errors = exception.Errors
		};

		return problemDetails;
	}
}
