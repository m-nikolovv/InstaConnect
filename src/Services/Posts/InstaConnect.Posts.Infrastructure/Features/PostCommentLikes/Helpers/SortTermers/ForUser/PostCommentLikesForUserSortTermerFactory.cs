using InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.SortTermers.ForUser;

internal class PostCommentLikesForUserSortTermerFactory : IPostCommentLikesForUserSortTermerFactory
{
	private readonly IEnumerable<IPostCommentLikesForUserSortTermer> _sortTermers;

	public PostCommentLikesForUserSortTermerFactory(IEnumerable<IPostCommentLikesForUserSortTermer> sortTermers)
	{
		_sortTermers = sortTermers;
	}

	public IPostCommentLikesForUserSortTermer Create(PostCommentLikesForUserSortTerm sortTerm)
	{
		var sortTermer = _sortTermers.FirstOrDefault(s => s.SortTerm == sortTerm);

		if (sortTermer == null)
		{
			throw new PostCommentLikesForUserSortTermNotSupportedException(sortTerm);
		}

		return sortTermer;
	}
}
