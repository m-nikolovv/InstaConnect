namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includers;

internal class PostCommentIncluderFactory : IPostCommentIncluderFactory
{
	private readonly IEnumerable<IPostCommentIncluder> _includers;

	public PostCommentIncluderFactory(IEnumerable<IPostCommentIncluder> includers)
	{
		_includers = includers;
	}

	public IEnumerable<IPostCommentIncluder> Create(ICollection<PostsIncludeDescriptor> descriptors)
	{
		var includers = _includers.Where(s => descriptors.Any(p =>
														p.IncludeType == s.IncludeType &&
														p.DestinationType == s.DestinationType));

		return includers;
	}
}
