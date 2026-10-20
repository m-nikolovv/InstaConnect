namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentLikeIncluderFactory : IPostCommentLikeIncluderFactory
{
	private readonly IEnumerable<IPostCommentLikeIncluder> _includers;

	public PostCommentLikeIncluderFactory(IEnumerable<IPostCommentLikeIncluder> includeProperties)
	{
		_includers = includeProperties;
	}

	public IEnumerable<IPostCommentLikeIncluder> Create(ICollection<PostsIncludeDescriptor> descriptors)
	{
		var includers = _includers.Where(s => descriptors.Any(p =>
														p.IncludeType == s.IncludeType &&
														p.DestinationType == s.DestinationType));

		return includers;
	}
}
