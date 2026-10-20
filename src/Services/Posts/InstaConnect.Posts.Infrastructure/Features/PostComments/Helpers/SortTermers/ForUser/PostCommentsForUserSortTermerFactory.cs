using InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.SortTermers.ForUser;

internal class PostCommentsForUserSortTermerFactory : IPostCommentsForUserSortTermerFactory
{
	private readonly IEnumerable<IPostCommentsForUserSortTermer> _sortTermers;

	public PostCommentsForUserSortTermerFactory(IEnumerable<IPostCommentsForUserSortTermer> sortTermers)
	{
		_sortTermers = sortTermers;
	}

	public IPostCommentsForUserSortTermer Create(PostCommentsForUserSortTerm sortTerm)
	{
		var sortTermer = _sortTermers.FirstOrDefault(s => s.SortTerm == sortTerm);

		if (sortTermer == null)
		{
			throw new PostCommentsForUserSortTermNotSupportedException(sortTerm);
		}

		return sortTermer;
	}
}
