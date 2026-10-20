using InstaConnect.Chats.Domain.Features.Chats.Exceptions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.SortTermers;

internal class ChatsSortTermerFactory : IChatsSortTermerFactory
{
	private readonly IEnumerable<IChatsSortTermer> _sortTermer;

	public ChatsSortTermerFactory(IEnumerable<IChatsSortTermer> sortTermer)
	{
		_sortTermer = sortTermer;
	}

	public IChatsSortTermer Create(ChatsSortTerm sortTerm)
	{
		var sortTermer = _sortTermer.FirstOrDefault(s => s.SortTerm == sortTerm);

		if (sortTermer == null)
		{
			throw new ChatsSortTermNotSupportedException(sortTerm);
		}

		return sortTermer;
	}
}
