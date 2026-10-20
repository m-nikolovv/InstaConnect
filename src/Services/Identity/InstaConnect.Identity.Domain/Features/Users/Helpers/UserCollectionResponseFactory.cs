namespace InstaConnect.Identity.Domain.Features.Users.Helpers;

internal class UserCollectionResponseFactory : IUserCollectionResponseFactory
{
	private readonly IPaginator _paginator;

	public UserCollectionResponseFactory(IPaginator paginator)
	{
		_paginator = paginator;
	}

	public UserCollectionResponse Create(ICollection<UserResponse> users, long totalCount, UsersPaginationQuery pagination)
	{
		var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
		var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

		return new UserCollectionResponse(
			users,
			pagination.Page,
			pagination.PageSize,
			totalCount,
			hasNextPage,
			hasPreviousPage);
	}
}
