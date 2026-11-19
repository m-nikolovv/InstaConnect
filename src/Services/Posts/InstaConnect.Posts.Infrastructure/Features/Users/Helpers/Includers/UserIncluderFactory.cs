namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Includers;

internal class UserIncluderFactory
	: IncluderFactory<PostsIncludeType, PostsDestinationType, PostsIncludeDescriptor, IUserIncluder, User>, IUserIncluderFactory
{
	public UserIncluderFactory(IEnumerable<IUserIncluder> includers) : base(includers)
	{
	}
}
