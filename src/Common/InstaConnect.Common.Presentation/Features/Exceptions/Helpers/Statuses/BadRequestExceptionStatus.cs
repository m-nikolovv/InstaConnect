namespace InstaConnect.Common.Presentation.Features.Exceptions.Helpers.Statuses;

internal class BadRequestExceptionStatus : IBaseExceptionStatus
{
	public BaseExceptionStatus Status => BaseExceptionStatus.BadRequest;

	public ApplicationProblemDetails GetApplicationProblemDetails(BaseException exception)
	{
		return new ApplicationProblemDetails
		{
			Title = Status.ToString(),
			Type = exception.GetType().Name,
			Status = StatusCodes.Status400BadRequest,
			Detail = exception.Message,
		};
	}
}
