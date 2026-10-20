namespace InstaConnect.Posts.Domain.Features.PostComments.Helpers;

internal class PostCommentCollectionResponseFactory : IPostCommentCollectionResponseFactory
{
	private readonly IPaginator _paginator;

	public PostCommentCollectionResponseFactory(IPaginator paginator)
	{
		_paginator = paginator;
	}

	public PostCommentCollectionResponse Create(
		PostResponse? post,
		ICollection<PostCommentResponse> postComments,
		long totalCount,
		PostCommentsPaginationQuery pagination)
	{
		var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
		var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

		return new PostCommentCollectionResponse(
			post,
			null,
			postComments,
			pagination.Page,
			pagination.PageSize,
			totalCount,
			hasNextPage,
			hasPreviousPage);
	}

	public PostCommentCollectionResponse CreateForUser(
		UserResponse? user,
		ICollection<PostCommentResponse> postComments,
		long totalCount,
		PostCommentsPaginationQuery pagination)
	{
		var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
		var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

		return new PostCommentCollectionResponse(
			null,
			user,
			postComments,
			pagination.Page,
			pagination.PageSize,
			totalCount,
			hasNextPage,
			hasPreviousPage);
	}
}
