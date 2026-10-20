namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Includers;

internal class PostIncluderFactory : IPostIncluderFactory
{
	private readonly IEnumerable<IPostIncluder> _includers;

	public PostIncluderFactory(IEnumerable<IPostIncluder> includers)
	{
		_includers = includers;
	}

	public IEnumerable<IPostIncluder> Create(ICollection<PostsIncludeDescriptor> descriptors)
	{
		var includers = _includers.Where(s => descriptors.Any(p =>
														p.IncludeType == s.IncludeType &&
														p.DestinationType == s.DestinationType));

		return includers;
	}
}
