namespace InstaConnect.Common.Presentation.Features.Exceptions.Helpers.Statuses;

internal class UnauthorizedExceptionStatus : IBaseExceptionStatus
{
	public BaseExceptionStatus Status => BaseExceptionStatus.Unauthorized;

	public ApplicationProblemDetails GetApplicationProblemDetails(BaseException exception)
	{
		return new ApplicationProblemDetails
		{
			Title = Status.ToString(),
			Type = exception.GetType().Name,
			Status = StatusCodes.Status401Unauthorized,
			Detail = exception.Message,
		};
	}
}
