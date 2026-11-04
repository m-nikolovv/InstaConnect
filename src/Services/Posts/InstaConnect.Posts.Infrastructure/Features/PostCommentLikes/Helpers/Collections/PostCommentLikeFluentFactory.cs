using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeFluentFactory : IPostCommentLikeFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostCommentLikeIncluderFactory _includerFactory;
	private readonly IPostCommentLikesSortTermerFactory _sortTermerFactory;
	private readonly IPostCommentLikeIncludeBuilderFactory _includeBuilderFactory;
	private readonly IPostCommentLikeResponseFluentFactory _responseFluentFactory;
	private readonly IPostCommentLikesForUserSortTermerFactory _forUserSortTermerFactory;

	public PostCommentLikeFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostCommentLikeIncluderFactory includerFactory,
		IPostCommentLikesSortTermerFactory sortTermerFactory,
		IPostCommentLikeIncludeBuilderFactory includeBuilderFactory,
		IPostCommentLikeResponseFluentFactory responseFluentFactory,
		IPostCommentLikesForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_includeBuilderFactory = includeBuilderFactory;
		_responseFluentFactory = responseFluentFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostCommentLikeFluent Create(IAggregateFluent<PostCommentLike> fluent)
	{
		return new PostCommentLikeFluent(
			fluent,
			_paginator,
			_sortOrdererFactory,
			_includerFactory,
			_sortTermerFactory,
			_includeBuilderFactory,
			_responseFluentFactory,
			_forUserSortTermerFactory);
	}
}
