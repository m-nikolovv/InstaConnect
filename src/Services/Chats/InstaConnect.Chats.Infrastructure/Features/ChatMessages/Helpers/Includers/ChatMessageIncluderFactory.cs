namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Includers;

internal class ChatMessageIncluderFactory : IChatMessageIncluderFactory
{
	private readonly IEnumerable<IChatMessageIncluder> _includers;

	public ChatMessageIncluderFactory(IEnumerable<IChatMessageIncluder> includers)
	{
		_includers = includers;
	}

	public IEnumerable<IChatMessageIncluder> Create(ICollection<ChatsIncludeDescriptor> descriptors)
	{
		var includers = _includers.Where(s => descriptors.Any(p =>
														p.IncludeType == s.IncludeType &&
														p.DestinationType == s.DestinationType));

		return includers;
	}
}
