namespace InstaConnect.Posts.Domain.Features.Posts.Helpers;

internal class PostCollectionResponseFactory : IPostCollectionResponseFactory
{
	private readonly IPaginator _paginator;

	public PostCollectionResponseFactory(IPaginator paginator)
	{
		_paginator = paginator;
	}

	public PostCollectionResponse Create(ICollection<PostResponse> posts, long totalCount, PostsPaginationQuery pagination)
	{
		var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
		var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

		return new PostCollectionResponse(
			null,
			posts,
			pagination.Page,
			pagination.PageSize,
			totalCount,
			hasNextPage,
			hasPreviousPage);
	}

	public PostCollectionResponse CreateForUser(UserResponse user, ICollection<PostResponse> posts, long totalCount, PostsPaginationQuery pagination)
	{
		var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
		var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

		return new PostCollectionResponse(
			user,
			posts,
			pagination.Page,
			pagination.PageSize,
			totalCount,
			hasNextPage,
			hasPreviousPage);
	}
}
