namespace InstaConnect.Common.Presentation.Features.Exceptions.Helpers.Statuses;

internal class ForbiddenExceptionStatus : IBaseExceptionStatus
{
	public BaseExceptionStatus Status => BaseExceptionStatus.Forbidden;

	public ApplicationProblemDetails GetApplicationProblemDetails(BaseException exception)
	{
		return new ApplicationProblemDetails
		{
			Title = Status.ToString(),
			Type = exception.GetType().Name,
			Status = StatusCodes.Status403Forbidden,
			Detail = exception.Message,
		};
	}
}
