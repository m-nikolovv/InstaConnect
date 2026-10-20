using InstaConnect.Posts.Domain.Features.Posts.Exceptions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.SortTermers.ForUser;

internal class PostsForUserSortTermerFactory : IPostsForUserSortTermerFactory
{
	private readonly IEnumerable<IPostsForUserSortTermer> _sortTermer;

	public PostsForUserSortTermerFactory(IEnumerable<IPostsForUserSortTermer> sortTermer)
	{
		_sortTermer = sortTermer;
	}

	public IPostsForUserSortTermer Create(PostsForUserSortTerm sortTerm)
	{
		var sortTermer = _sortTermer.FirstOrDefault(s => s.SortTerm == sortTerm);

		if (sortTermer == null)
		{
			throw new PostsForUserSortTermNotSupportedException(sortTerm);
		}

		return sortTermer;
	}
}
