using InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.SortTermers.ForUser;

internal class PostLikesForUserSortTermerFactory : IPostLikesForUserSortTermerFactory
{
	private readonly IEnumerable<IPostLikesForUserSortTermer> _sortTermer;

	public PostLikesForUserSortTermerFactory(IEnumerable<IPostLikesForUserSortTermer> sortTermer)
	{
		_sortTermer = sortTermer;
	}

	public IPostLikesForUserSortTermer Create(PostLikesForUserSortTerm sortTerm)
	{
		var sortTermer = _sortTermer.FirstOrDefault(s => s.SortTerm == sortTerm);

		if (sortTermer == null)
		{
			throw new PostLikesForUserSortTermNotSupportedException(sortTerm);
		}

		return sortTermer;
	}
}
