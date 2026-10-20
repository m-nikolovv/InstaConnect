namespace InstaConnect.Common.Presentation.Features.Exceptions.Abstractions;

public interface IBaseExceptionStatus
{
	public BaseExceptionStatus Status { get; }

	public ApplicationProblemDetails GetApplicationProblemDetails(BaseException exception);
}
