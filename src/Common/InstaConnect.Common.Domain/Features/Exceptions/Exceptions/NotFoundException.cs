namespace InstaConnect.Common.Domain.Features.Exceptions.Exceptions;

public class NotFoundException : BaseException
{
	public NotFoundException(string message) : base(message, BaseExceptionStatus.NotFound)
	{
	}

	public NotFoundException(string message, Exception exception) : base(message, BaseExceptionStatus.NotFound, exception)
	{
	}
}
