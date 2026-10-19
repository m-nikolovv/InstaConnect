using InstaConnect.Common.Domain.Features.Exceptions.Exceptions;

namespace InstaConnect.Chats.Domain.Features.Chats.Exceptions;

public class ChatAlreadyExistsException : BadRequestException
{
	public ChatAlreadyExistsException(ChatId id)
		: base(ChatExceptionErrorMessages.GetAlreadyExistsMessage(id))
	{
	}

	public ChatAlreadyExistsException(ChatId id, Exception exception)
		: base(ChatExceptionErrorMessages.GetAlreadyExistsMessage(id), exception)
	{
	}
}
