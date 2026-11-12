using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Collections;

internal class UserClaimFluent : MongoDbFluent<UserClaim, UserClaimId>, IUserClaimFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IUserClaimIncluderFactory _includerFactory;
	private readonly IUserClaimsSortTermerFactory _sortTermerFactory;
	private readonly IUserClaimResponseFluentFactory _responseFluentFactory;

	public UserClaimFluent(
		IPaginator paginator,
		IAggregateFluent<UserClaim> fluent,
		ISortOrdererFactory sortOrdererFactory,
		IUserClaimIncluderFactory includerFactory,
		IUserClaimsSortTermerFactory sortTermerFactory,
		IUserClaimResponseFluentFactory responseFluentFactory) : base(fluent)
	{
		_paginator = paginator;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IUserClaimFluent ApplyIncludes(UserClaimInclude include)
	{
		ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IUserClaimFluent Match(UserClaimsFilterQuery filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IUserClaimFluent Match(UserClaimId filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IUserClaimFluent Match(IEnumerable<UserClaimId> filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IUserClaimFluent ApplySorting(UserClaimsSortingQuery query)
	{
		ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IUserClaimFluent ApplyPagination(UserClaimsPaginationQuery query)
	{
		ApplyPagination(_paginator, query);

		return this;
	}

	public IUserClaimResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser)
	{
		var projection = Builders<UserClaim>.Projection.Expression(
			uc => new UserClaimResponse(
				uc.Id,
				new UserResponse(
					uc.User!.Id,
					uc.User.FirstName,
					uc.User.LastName,
					uc.User.Email,
					uc.User.Name,
					uc.User.ProfileImageUrl,
					uc.User.CreatedAtUtc,
					uc.User.UpdatedAtUtc),
				uc.CreatedAtUtc));
		var fluent = Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IUserClaimResponseFluent ProjectToResponseWithoutUser(CurrentUserQuery currentUser)
	{
		var projection = Builders<UserClaim>.Projection.Expression(
			uc => new UserClaimResponse(
				uc.Id,
				null,
				uc.CreatedAtUtc));
		var fluent = Project(projection);

		return _responseFluentFactory.Create(fluent);
	}
}
