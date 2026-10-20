namespace InstaConnect.Common.Presentation.Features.Exceptions.Helpers.Statuses;

internal class NotFoundExceptionStatus : IBaseExceptionStatus
{
	public BaseExceptionStatus Status => BaseExceptionStatus.NotFound;

	public ApplicationProblemDetails GetApplicationProblemDetails(BaseException exception)
	{
		return new ApplicationProblemDetails
		{
			Title = Status.ToString(),
			Type = exception.GetType().Name,
			Status = StatusCodes.Status404NotFound,
			Detail = exception.Message,
		};
	}
}
