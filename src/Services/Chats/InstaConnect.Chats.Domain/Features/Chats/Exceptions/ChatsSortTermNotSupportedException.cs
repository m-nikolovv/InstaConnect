using InstaConnect.Chats.Domain.Features.Chats.Utilities;

namespace InstaConnect.Chats.Domain.Features.Chats.Exceptions;

public class ChatsSortTermNotSupportedException : BadRequestException
{
	public ChatsSortTermNotSupportedException(ChatsSortTerm sortTerm)
		: base(ChatExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
	{
	}

	public ChatsSortTermNotSupportedException(ChatsSortTerm sortTerm, Exception exception)
		: base(ChatExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
	{
	}
}
