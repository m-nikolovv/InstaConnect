using InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.SortTermers;

internal class PostCommentsSortTermerFactory : IPostCommentsSortTermerFactory
{
	private readonly IEnumerable<IPostCommentsSortTermer> _sortTermers;

	public PostCommentsSortTermerFactory(IEnumerable<IPostCommentsSortTermer> sortTermers)
	{
		_sortTermers = sortTermers;
	}

	public IPostCommentsSortTermer Create(PostCommentsSortTerm sortTerm)
	{
		var sortTermer = _sortTermers.FirstOrDefault(s => s.SortTerm == sortTerm);

		if (sortTermer == null)
		{
			throw new PostCommentsSortTermNotSupportedException(sortTerm);
		}

		return sortTermer;
	}
}
