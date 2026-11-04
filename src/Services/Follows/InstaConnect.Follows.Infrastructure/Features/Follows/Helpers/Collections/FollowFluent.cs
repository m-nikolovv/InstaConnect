using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowFluent : MongoDbFluent<Follow>, IFollowFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IFollowIncluderFactory _includerFactory;
	private readonly IFollowsSortTermerFactory _sortTermerFactory;
	private readonly IFollowIncludeBuilderFactory _includeBuilderFactory;
	private readonly IFollowResponseFluentFactory _responseFluentFactory;
	private readonly IFollowsForFollowingSortTermerFactory _forFollowingSortTermerFactory;

	public FollowFluent(
		IAggregateFluent<Follow> fluent,
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IFollowIncluderFactory includerFactory,
		IFollowsSortTermerFactory sortTermerFactory,
		IFollowIncludeBuilderFactory includeBuilderFactory,
		IFollowResponseFluentFactory responseFluentFactory,
		IFollowsForFollowingSortTermerFactory forFollowingSortTermerFactory) : base(fluent)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_includeBuilderFactory = includeBuilderFactory;
		_responseFluentFactory = responseFluentFactory;
		_forFollowingSortTermerFactory = forFollowingSortTermerFactory;
	}

	public IFollowFluent ApplyIncludes(FollowInclude include)
	{
		ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IFollowFluent Match(FollowsFilterQuery filter)
	{
		ApplyFollowingInclude();

		Match(filter.GetFilter());

		return this;
	}

	public IFollowFluent Match(FollowsForFollowingFilterQuery filter)
	{
		ApplyFollowerInclude();

		Match(filter.GetFilter());

		return this;
	}

	public IFollowFluent Match(FollowId filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IFollowFluent ApplySorting(FollowsSortingQuery query)
	{
		if (query.Term == FollowsSortTerm.ByFollowingName)
		{
			ApplyFollowingInclude();
		}

		ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IFollowFluent ApplySorting(FollowsForFollowingSortingQuery query)
	{
		if (query.Term == FollowsForFollowingSortTerm.ByFollowerName)
		{
			ApplyFollowerInclude();
		}

		ApplySorting(_sortOrdererFactory, _forFollowingSortTermerFactory, query);

		return this;
	}

	public IFollowFluent ApplyPagination(FollowsPaginationQuery query)
	{
		ApplyPagination(_paginator, query);

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

	private void ApplyFollowerInclude()
	{
		ApplyIncludes(_includeBuilderFactory.Create().WithFollower().Build());
	}

	private void ApplyFollowingInclude()
	{
		ApplyIncludes(_includeBuilderFactory.Create().WithFollowing().Build());
	}
}
