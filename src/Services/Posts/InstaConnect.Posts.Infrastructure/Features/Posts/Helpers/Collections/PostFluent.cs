using InstaConnect.Posts.Domain.Features.PostImages.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostFluent : MongoDbFluent<Post>, IPostFluent
{
	private readonly IPaginator _paginator;
	private readonly IPostIncluderFactory _includerFactory;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostsSortTermerFactory _sortTermerFactory;
	private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
	private readonly IPostResponseFluentFactory _responseFluentFactory;
	private readonly IPostsForUserSortTermerFactory _forUserSortTermerFactory;

	public PostFluent(
		IAggregateFluent<Post> fluent,
		IPaginator paginator,
		IPostIncluderFactory includerFactory,
		ISortOrdererFactory sortOrdererFactory,
		IPostsSortTermerFactory sortTermerFactory,
		IPostIncludeBuilderFactory includeBuilderFactory,
		IPostResponseFluentFactory responseFluentFactory,
		IPostsForUserSortTermerFactory forUserSortTermerFactory) : base(fluent)
	{
		_paginator = paginator;
		_includerFactory = includerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
		_includeBuilderFactory = includeBuilderFactory;
		_responseFluentFactory = responseFluentFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostFluent ApplyIncludes(PostInclude include)
	{
		ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IPostFluent Match(PostsFilterQuery filter)
	{
		ApplyUserInclude();

		Match(filter.GetFilter());

		return this;
	}

	public IPostFluent Match(PostsForUserFilterQuery filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IPostFluent Match(PostId filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IPostFluent ApplySorting(PostsSortingQuery query)
	{
		if (query.Term == PostsSortTerm.ByUserName)
		{
			ApplyUserInclude();
		}

		ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IPostFluent ApplySorting(PostsForUserSortingQuery query)
	{
		if (query.Term == PostsForUserSortTerm.ByUserName)
		{
			ApplyUserInclude();
		}

		ApplySorting(_sortOrdererFactory, _forUserSortTermerFactory, query);

		return this;
	}

	public IPostFluent ApplyPagination(PostsPaginationQuery query)
	{
		ApplyPagination(_paginator, query);

		return this;
	}

	public IPostResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id?.ToLower();
		var projection = Builders<Post>.Projection.Expression(
			 p => new PostResponse(
				 p.Id,
				 p.UserId,
				 p.Title,
				 p.Content,
				 p.Summary,
				 new UserResponse(
					 p.User!.Id,
					 p.User.FirstName,
					 p.User.LastName,
					 p.User.Email,
					 p.User.Name,
					 p.User.ProfileImageUrl,
					 p.User.CreatedAtUtc,
					 p.User.UpdatedAtUtc),
				 p.PostImages.Select(
					 pi => new PostImageResponse(
						 pi.Id,
						 pi.Url,
						 pi.CreatedAtUtc)).ToList(),
				 p.PostLikes.Any(
					 pl => pl.Id.UserId.Id.ToLower() == currentUserId),
				 p.PostLikes.Count,
				 p.PostComments.Count,
				 p.CreatedAtUtc,
				 p.UpdatedAtUtc));
		var fluent = Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IPostResponseFluent ProjectToResponseWithoutUser(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id?.ToLower();
		var projection = Builders<Post>.Projection.Expression(
			 p => new PostResponse(
				 p.Id,
				 p.UserId,
				 p.Title,
				 p.Content,
				 p.Summary,
				 null,
				 p.PostImages.Select(
					 pi => new PostImageResponse(
						 pi.Id,
						 pi.Url,
						 pi.CreatedAtUtc)).ToList(),
				 p.PostLikes.Any(
					 pl => pl.Id.UserId.Id.ToLower() == currentUserId),
				 p.PostLikes.Count,
				 p.PostComments.Count,
				 p.CreatedAtUtc,
				 p.UpdatedAtUtc));
		var fluent = Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	private void ApplyUserInclude()
	{
		ApplyIncludes(_includeBuilderFactory.Create().WithUser().Build());
	}
}
