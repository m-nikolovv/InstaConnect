using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Collections;

internal class UserClaimFluent : IUserClaimFluent
{
	private readonly IUserClaimIncluderFactory _includerFactory;
	private readonly IUserClaimResponseFluentFactory _responseFluentFactory;
	private readonly IMongoDbFluentHandler<UserClaim, UserClaimId> _fluentHandler;

	public UserClaimFluent(
		IUserClaimIncluderFactory includerFactory,
		IUserClaimResponseFluentFactory responseFluentFactory,
		IMongoDbFluentHandler<UserClaim, UserClaimId> fluentHandler)
	{
		_fluentHandler = fluentHandler;
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IUserClaimFluent Include(UserClaimInclude include)
	{
		_fluentHandler.Include(_includerFactory, include);

		return this;
	}

	public IUserClaimFluent Match(UserClaimsFilterQuery filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IUserClaimFluent Match(UserClaimId filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IUserClaimFluent Match(IEnumerable<UserClaimId> filter)
	{
		_fluentHandler.Match(filter.GetFilter());

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
		var fluent = _fluentHandler.Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IUserClaimResponseFluent ProjectToResponseWithoutUser(CurrentUserQuery currentUser)
	{
		var projection = Builders<UserClaim>.Projection.Expression(
			uc => new UserClaimResponse(
				uc.Id,
				null,
				uc.CreatedAtUtc));
		var fluent = _fluentHandler.Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IMongoDbFluent<UserClaim, UserClaimId> Match(FilterDefinition<UserClaim> filterDefinition)
	{
		_fluentHandler.Match(filterDefinition);

		return this;
	}

	public async Task<UserClaim?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<long> GetCountAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetCountAsync(cancellationToken);
	}

	public async Task<ICollection<UserClaim>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}

	public async Task<bool> AnyAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.AnyAsync(cancellationToken);
	}

	public async Task<ICollection<UserClaimId>> GetIdsAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetIdsAsync(cancellationToken);
	}
}
