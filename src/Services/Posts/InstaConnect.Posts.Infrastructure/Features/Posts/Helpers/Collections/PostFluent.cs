using InstaConnect.Posts.Domain.Features.PostImages.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostFluent : IPostFluent
{
	private readonly IPaginator _paginator;
	private readonly IPostIncluderFactory _includerFactory;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostsSortTermerFactory _sortTermerFactory;
	private readonly IPostResponseFluentFactory _responseFluentFactory;
	private readonly IMongoDbFluentHandler<Post, PostId> _fluentHandler;
	private readonly IPostsForUserSortTermerFactory _forUserSortTermerFactory;

	public PostFluent(
		IPaginator paginator,
		IPostIncluderFactory includerFactory,
		ISortOrdererFactory sortOrdererFactory,
		IPostsSortTermerFactory sortTermerFactory,
		IPostResponseFluentFactory responseFluentFactory,
		IMongoDbFluentHandler<Post, PostId> fluentHandler,
		IPostsForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_fluentHandler = fluentHandler;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_responseFluentFactory = responseFluentFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostFluent ApplyIncludes(PostInclude include)
	{
		_fluentHandler.ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IPostFluent Match(PostsFilterQuery filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IPostFluent Match(PostsForUserFilterQuery filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IPostFluent Match(PostId filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IPostFluent Match(IEnumerable<PostId> filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IPostFluent ApplySorting(PostsSortingQuery query)
	{
		_fluentHandler.ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IPostFluent ApplySorting(PostsForUserSortingQuery query)
	{
		_fluentHandler.ApplySorting(_sortOrdererFactory, _forUserSortTermerFactory, query);

		return this;
	}

	public IPostFluent ApplyPagination(PostsPaginationQuery query)
	{
		_fluentHandler.ApplyPagination(_paginator, query);

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
		var fluent = _fluentHandler.Project(projection);

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
		var fluent = _fluentHandler.Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IMongoDbFluent<Post, PostId> Match(FilterDefinition<Post> filterDefinition)
	{
		_fluentHandler.Match(filterDefinition);

		return this;
	}

	public async Task<Post?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<long> GetCountAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetCountAsync(cancellationToken);
	}

	public async Task<ICollection<Post>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}

	public async Task<bool> AnyAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.AnyAsync(cancellationToken);
	}

	public async Task<ICollection<PostId>> GetIdsAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetIdsAsync(cancellationToken);
	}
}
