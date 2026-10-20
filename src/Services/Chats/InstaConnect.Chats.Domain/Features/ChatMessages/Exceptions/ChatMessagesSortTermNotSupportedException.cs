using InstaConnect.Chats.Domain.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Exceptions;

public class ChatMessagesSortTermNotSupportedException : BadRequestException
{
	public ChatMessagesSortTermNotSupportedException(ChatMessagesSortTerm sortTerm)
		: base(ChatMessageExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
	{
	}

	public ChatMessagesSortTermNotSupportedException(ChatMessagesSortTerm sortTerm, Exception exception)
		: base(ChatMessageExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
	{
	}
}
