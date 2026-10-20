namespace InstaConnect.Common.Domain.Features.Exceptions.Exceptions;

public class BaseException : Exception
{
	protected BaseException(string message, BaseExceptionStatus status) : base(message)
	{
		Message = message;
		Status = status;
	}

	protected BaseException(string message, BaseExceptionStatus status, Exception exception) : base(message, exception)
	{
		Message = message;
		Status = status;
	}

	public override string Message { get; }
	public BaseExceptionStatus Status { get; }
}
