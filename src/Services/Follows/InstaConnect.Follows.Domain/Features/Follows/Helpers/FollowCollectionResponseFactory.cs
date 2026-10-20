using InstaConnect.Common.Domain.Features.Databases.Abstractions;

namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

internal class FollowCollectionResponseFactory : IFollowCollectionResponseFactory
{
	private readonly IPaginator _paginator;

	public FollowCollectionResponseFactory(IPaginator paginator)
	{
		_paginator = paginator;
	}

	public FollowCollectionResponse Create(UserResponse follower, ICollection<FollowResponse> follows, long totalCount, FollowsPaginationQuery pagination)
	{
		var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
		var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

		return new FollowCollectionResponse(
			follower,
			null,
			follows,
			pagination.Page,
			pagination.PageSize,
			totalCount,
			hasNextPage,
			hasPreviousPage);
	}

	public FollowCollectionResponse CreateForFollowing(UserResponse following, ICollection<FollowResponse> follows, long totalCount, FollowsPaginationQuery pagination)
	{
		var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
		var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

		return new FollowCollectionResponse(
			null,
			following,
			follows,
			pagination.Page,
			pagination.PageSize,
			totalCount,
			hasNextPage,
			hasPreviousPage);
	}
}
