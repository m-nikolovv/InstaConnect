using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowFluent : IFollowFluent
{
	private readonly IFollowIncluderFactory _includerFactory;
	private readonly IFollowResponseFluentFactory _responseFluentFactory;
	private readonly IMongoDbFluentHandler<Follow, FollowId> _fluentHandler;

	public FollowFluent(
		IFollowIncluderFactory includerFactory,
		IFollowResponseFluentFactory responseFluentFactory,
		IMongoDbFluentHandler<Follow, FollowId> fluentHandler)
	{
		_fluentHandler = fluentHandler;
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IFollowFluent Include(FollowInclude include)
	{
		_fluentHandler.Include(_includerFactory, include);

		return this;
	}

	public IFollowFluent Match(FollowsFilterQuery filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IFollowFluent Match(FollowsForFollowingFilterQuery filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IFollowFluent Match(FollowId filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IFollowFluent Match(IEnumerable<FollowId> filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IFollowResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id?.ToLower();
		var projection = Builders<Follow>.Projection.Expression(
			 p => new FollowResponse(
				 p.Id,
				 new UserResponse(
					 p.Follower!.Id,
					 p.Follower.FirstName,
					 p.Follower.LastName,
					 p.Follower.Email,
					 p.Follower.Name,
					 p.Follower.ProfileImageUrl,
					 p.Follower.CreatedAtUtc,
					 p.Follower.UpdatedAtUtc),
				 new UserResponse(
					 p.Following!.Id,
					 p.Following.FirstName,
					 p.Following.LastName,
					 p.Following.Email,
					 p.Following.Name,
					 p.Following.ProfileImageUrl,
					 p.Following.CreatedAtUtc,
					 p.Following.UpdatedAtUtc),
				 p.Id.FollowerId.Id.ToLower() == currentUserId,
				 p.CreatedAtUtc));
		var fluent = _fluentHandler.Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IFollowResponseFluent ProjectToResponseWithoutFollower(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id?.ToLower();
		var projection = Builders<Follow>.Projection.Expression(
			 p => new FollowResponse(
				 p.Id,
				 null,
				 new UserResponse(
					 p.Following!.Id,
					 p.Following.FirstName,
					 p.Following.LastName,
					 p.Following.Email,
					 p.Following.Name,
					 p.Following.ProfileImageUrl,
					 p.Following.CreatedAtUtc,
					 p.Following.UpdatedAtUtc),
				 p.Id.FollowerId.Id.ToLower() == currentUserId,
				 p.CreatedAtUtc));
		var fluent = _fluentHandler.Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IFollowResponseFluent ProjectToResponseWithoutFollowing(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id?.ToLower();
		var projection = Builders<Follow>.Projection.Expression(
			 p => new FollowResponse(
				 p.Id,
				 new UserResponse(
					 p.Follower!.Id,
					 p.Follower.FirstName,
					 p.Follower.LastName,
					 p.Follower.Email,
					 p.Follower.Name,
					 p.Follower.ProfileImageUrl,
					 p.Follower.CreatedAtUtc,
					 p.Follower.UpdatedAtUtc),
				 null,
				 p.Id.FollowerId.Id.ToLower() == currentUserId,
				 p.CreatedAtUtc));
		var fluent = _fluentHandler.Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IMongoDbFluent<Follow, FollowId> Match(FilterDefinition<Follow> filterDefinition)
	{
		_fluentHandler.Match(filterDefinition);

		return this;
	}

	public async Task<Follow?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<long> GetCountAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetCountAsync(cancellationToken);
	}

	public async Task<ICollection<Follow>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}

	public async Task<bool> AnyAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.AnyAsync(cancellationToken);
	}

	public async Task<ICollection<FollowId>> GetIdsAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetIdsAsync(cancellationToken);
	}
}
