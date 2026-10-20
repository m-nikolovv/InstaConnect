using InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.SortTermers;

internal class PostCommentLikesSortTermerFactory : IPostCommentLikesSortTermerFactory
{
	private readonly IEnumerable<IPostCommentLikesSortTermer> _sortTermers;

	public PostCommentLikesSortTermerFactory(IEnumerable<IPostCommentLikesSortTermer> sortTermers)
	{
		_sortTermers = sortTermers;
	}

	public IPostCommentLikesSortTermer Create(PostCommentLikesSortTerm sortTerm)
	{
		var sortTermer = _sortTermers.FirstOrDefault(s => s.SortTerm == sortTerm);

		if (sortTermer == null)
		{
			throw new PostCommentLikesSortTermNotSupportedException(sortTerm);
		}

		return sortTermer;
	}
}
