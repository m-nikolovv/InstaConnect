using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Collections;

internal class UserClaimFluent : MongoDbFluent<UserClaim>, IUserClaimFluent
{
	private readonly IUserClaimIncluderFactory _includerFactory;
	private readonly IUserClaimResponseFluentFactory _responseFluentFactory;

	public UserClaimFluent(
		IAggregateFluent<UserClaim> fluent,
		IUserClaimIncluderFactory includerFactory,
		IUserClaimResponseFluentFactory responseFluentFactory) : base(fluent)
	{
		_includerFactory = includerFactory;
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
