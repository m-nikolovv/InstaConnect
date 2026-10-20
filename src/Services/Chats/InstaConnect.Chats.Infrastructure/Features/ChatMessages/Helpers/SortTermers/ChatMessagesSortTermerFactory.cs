using InstaConnect.Chats.Domain.Features.ChatMessages.Exceptions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.SortTermers;

internal class ChatMessagesSortTermerFactory : IChatMessagesSortTermerFactory
{
	private readonly IEnumerable<IChatMessagesSortTermer> _sortTermer;

	public ChatMessagesSortTermerFactory(IEnumerable<IChatMessagesSortTermer> sortTermer)
	{
		_sortTermer = sortTermer;
	}

	public IChatMessagesSortTermer Create(ChatMessagesSortTerm sortTerm)
	{
		var sortTermer = _sortTermer.FirstOrDefault(s => s.SortTerm == sortTerm);

		if (sortTermer == null)
		{
			throw new ChatMessagesSortTermNotSupportedException(sortTerm);
		}

		return sortTermer;
	}
}
