using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Follows.Domain.Features.Users.Models.Responses;
using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowFluent : MongoDbFluent<Follow>, IFollowFluent
{
	private readonly IFollowIncluderFactory _includerFactory;
	private readonly IFollowResponseFluentFactory _responseFluentFactory;

	public FollowFluent(
		IAggregateFluent<Follow> fluent,
		IFollowIncluderFactory includerFactory,
		IFollowResponseFluentFactory responseFluentFactory) : base(fluent)
	{
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IFollowFluent ApplyIncludes(FollowInclude include)
	{
		ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IFollowFluent Match(FollowsFilterQuery filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IFollowFluent Match(FollowsForFollowingFilterQuery filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IFollowFluent Match(FollowId filter)
	{
		Match(filter.GetFilter());

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
		var fluent = Project(projection);

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
		var fluent = Project(projection);

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
		var fluent = Project(projection);

		return _responseFluentFactory.Create(fluent);
	}
}
