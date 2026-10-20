namespace InstaConnect.Posts.Domain.Features.PostLikes.Helpers;

internal class PostLikeCollectionResponseFactory : IPostLikeCollectionResponseFactory
{
	private readonly IPaginator _paginator;

	public PostLikeCollectionResponseFactory(IPaginator paginator)
	{
		_paginator = paginator;
	}

	public PostLikeCollectionResponse Create(
		PostResponse? post,
		ICollection<PostLikeResponse> postLikes,
		long totalCount,
		PostLikesPaginationQuery pagination)
	{
		var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
		var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

		return new PostLikeCollectionResponse(
			post,
			null,
			postLikes,
			pagination.Page,
			pagination.PageSize,
			totalCount,
			hasNextPage,
			hasPreviousPage);
	}

	public PostLikeCollectionResponse CreateForUser(
		UserResponse? user,
		ICollection<PostLikeResponse> postLikes,
		long totalCount,
		PostLikesPaginationQuery pagination)
	{
		var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
		var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

		return new PostLikeCollectionResponse(
			null,
			user,
			postLikes,
			pagination.Page,
			pagination.PageSize,
			totalCount,
			hasNextPage,
			hasPreviousPage);
	}
}
