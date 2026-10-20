namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Includers;

internal class ChatIncluderFactory : IChatIncluderFactory
{
	private readonly IEnumerable<IChatIncluder> _includers;

	public ChatIncluderFactory(IEnumerable<IChatIncluder> includers)
	{
		_includers = includers;
	}

	public IEnumerable<IChatIncluder> Create(ICollection<ChatsIncludeDescriptor> descriptors)
	{
		var includers = _includers.Where(s => descriptors.Any(p =>
														p.IncludeType == s.IncludeType &&
														p.DestinationType == s.DestinationType));

		return includers;
	}
}
