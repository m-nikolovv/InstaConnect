namespace InstaConnect.Identity.Domain.Features.UserClaims.Helpers;

internal class UserClaimCollectionResponseFactory : IUserClaimCollectionResponseFactory
{
	private readonly IPaginator _paginator;

	public UserClaimCollectionResponseFactory(IPaginator paginator)
	{
		_paginator = paginator;
	}

	public UserClaimCollectionResponse Create(
		UserResponse? user,
		ICollection<UserClaimResponse> userClaims,
		long totalCount,
		UserClaimsPaginationQuery pagination)
	{
		var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
		var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

		return new UserClaimCollectionResponse(
			user,
			userClaims,
			pagination.Page,
			pagination.PageSize,
			totalCount,
			hasNextPage,
			hasPreviousPage);
	}
}
