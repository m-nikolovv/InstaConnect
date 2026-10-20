namespace InstaConnect.Common.Domain.Features.Exceptions.Exceptions;

public class ForbiddenException : BaseException
{
	public ForbiddenException(string message) : base(message, BaseExceptionStatus.Forbidden)
	{
	}

	public ForbiddenException(string message, Exception exception) : base(message, BaseExceptionStatus.Forbidden, exception)
	{
	}
}
