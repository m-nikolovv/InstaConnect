namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;

internal class PostCommentLikeCollectionResponseFactory : IPostCommentLikeCollectionResponseFactory
{
	private readonly IPaginator _paginator;

	public PostCommentLikeCollectionResponseFactory(IPaginator paginator)
	{
		_paginator = paginator;
	}

	public PostCommentLikeCollectionResponse Create(
		PostCommentResponse? postComment,
		ICollection<PostCommentLikeResponse> postCommentLikes,
		long totalCount,
		PostCommentLikesPaginationQuery pagination)
	{
		var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
		var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

		return new PostCommentLikeCollectionResponse(
			postComment,
			null,
			postCommentLikes,
			pagination.Page,
			pagination.PageSize,
			totalCount,
			hasNextPage,
			hasPreviousPage);
	}

	public PostCommentLikeCollectionResponse CreateForUser(
		UserResponse? user,
		ICollection<PostCommentLikeResponse> postCommentLikes,
		long totalCount,
		PostCommentLikesPaginationQuery pagination)
	{
		var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
		var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

		return new PostCommentLikeCollectionResponse(
			null,
			user,
			postCommentLikes,
			pagination.Page,
			pagination.PageSize,
			totalCount,
			hasNextPage,
			hasPreviousPage);
	}
}
