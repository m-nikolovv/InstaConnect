namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Includers;

internal class UserIncluderFactory
	: IncluderFactory<ChatsIncludeType, ChatsDestinationType, ChatsIncludeDescriptor, IUserIncluder, User>, IUserIncluderFactory
{
	public UserIncluderFactory(IEnumerable<IUserIncluder> includers) : base(includers)
	{
	}
}
