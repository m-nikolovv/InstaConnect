using InstaConnect.Posts.Domain.Features.Posts.Exceptions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.SortTermers;

internal class PostsSortTermerFactory : IPostsSortTermerFactory
{
	private readonly IEnumerable<IPostsSortTermer> _sortTermer;

	public PostsSortTermerFactory(IEnumerable<IPostsSortTermer> sortTermer)
	{
		_sortTermer = sortTermer;
	}

	public IPostsSortTermer Create(PostsSortTerm sortTerm)
	{
		var sortTermer = _sortTermer.FirstOrDefault(s => s.SortTerm == sortTerm);

		if (sortTermer == null)
		{
			throw new PostsSortTermNotSupportedException(sortTerm);
		}

		return sortTermer;
	}
}
