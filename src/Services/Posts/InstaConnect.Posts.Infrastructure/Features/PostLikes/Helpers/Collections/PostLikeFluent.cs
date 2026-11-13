using InstaConnect.Posts.Domain.Features.PostImages.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeFluent : IPostLikeFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostLikeIncluderFactory _includerFactory;
	private readonly IPostLikesSortTermerFactory _sortTermerFactory;
	private readonly IPostLikeResponseFluentFactory _responseFluentFactory;
	private readonly IMongoDbFluentHandler<PostLike, PostLikeId> _fluentHandler;
	private readonly IPostLikesForUserSortTermerFactory _forUserSortTermerFactory;

	public PostLikeFluent(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostLikeIncluderFactory includerFactory,
		IPostLikesSortTermerFactory sortTermerFactory,
		IPostLikeResponseFluentFactory responseFluentFactory,
		IMongoDbFluentHandler<PostLike, PostLikeId> fluentHandler,
		IPostLikesForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_fluentHandler = fluentHandler;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_responseFluentFactory = responseFluentFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostLikeFluent ApplyIncludes(PostLikeInclude include)
	{
		_fluentHandler.ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IPostLikeFluent Match(PostLikesFilterQuery filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IPostLikeFluent Match(PostLikesForUserFilterQuery filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IPostLikeFluent Match(PostLikeId filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IPostLikeFluent Match(IEnumerable<PostLikeId> filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IPostLikeFluent ApplySorting(PostLikesSortingQuery query)
	{
		_fluentHandler.ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IPostLikeFluent ApplySorting(PostLikesForUserSortingQuery query)
	{
		_fluentHandler.ApplySorting(_sortOrdererFactory, _forUserSortTermerFactory, query);

		return this;
	}

	public IPostLikeFluent ApplyPagination(PostLikesPaginationQuery query)
	{
		_fluentHandler.ApplyPagination(_paginator, query);

		return this;
	}

	public IPostLikeResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id?.ToLower();
		var projection = Builders<PostLike>.Projection.Expression(
			p => new PostLikeResponse(
				p.Id,
				new UserResponse(
					p.User!.Id,
					p.User.FirstName,
					p.User.LastName,
					p.User.Email,
					p.User.Name,
					p.User.ProfileImageUrl,
					p.User.CreatedAtUtc,
					p.User.UpdatedAtUtc),
				new PostResponse(
					p.Post!.Id,
					p.Post.UserId,
					p.Post.Title,
					p.Post.Content,
					p.Post.Summary,
						new UserResponse(
							p.Post.User!.Id,
							p.Post.User.FirstName,
							p.Post.User.LastName,
							p.Post.User.Email,
							p.Post.User.Name,
							p.Post.User.ProfileImageUrl,
							p.Post.User.CreatedAtUtc,
							p.Post.User.UpdatedAtUtc),
					p.Post.PostImages.Select(
						pi => new PostImageResponse(
							pi.Id,
							pi.Url,
							pi.CreatedAtUtc)).ToList(),
					p.Post.PostLikes.Any(
						pl => pl.Id.UserId.Id.ToLower() == currentUserId),
					p.Post.PostLikes.Count,
					p.Post.PostComments.Count,
					p.Post.CreatedAtUtc,
					p.Post.UpdatedAtUtc),
				p.CreatedAtUtc));
		var fluent = _fluentHandler.Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IPostLikeResponseFluent ProjectToResponseWithoutUser(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id?.ToLower();
		var projection = Builders<PostLike>.Projection.Expression(
			p => new PostLikeResponse(
				p.Id,
				null,
				new PostResponse(
					p.Post!.Id,
					p.Post.UserId,
					p.Post.Title,
					p.Post.Content,
					p.Post.Summary,
						new UserResponse(
							p.Post.User!.Id,
							p.Post.User.FirstName,
							p.Post.User.LastName,
							p.Post.User.Email,
							p.Post.User.Name,
							p.Post.User.ProfileImageUrl,
							p.Post.User.CreatedAtUtc,
							p.Post.User.UpdatedAtUtc),
					p.Post.PostImages.Select(
						pi => new PostImageResponse(
							pi.Id,
							pi.Url,
							pi.CreatedAtUtc)).ToList(),
					p.Post.PostLikes.Any(
						pl => pl.Id.UserId.Id.ToLower() == currentUserId),
					p.Post.PostLikes.Count,
					p.Post.PostComments.Count,
					p.Post.CreatedAtUtc,
					p.Post.UpdatedAtUtc),
				p.CreatedAtUtc));
		var fluent = _fluentHandler.Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IPostLikeResponseFluent ProjectToResponseWithoutPost(CurrentUserQuery currentUser)
	{
		var projection = Builders<PostLike>.Projection.Expression(
			p => new PostLikeResponse(
				p.Id,
				new UserResponse(
					p.User!.Id,
					p.User.FirstName,
					p.User.LastName,
					p.User.Email,
					p.User.Name,
					p.User.ProfileImageUrl,
					p.User.CreatedAtUtc,
					p.User.UpdatedAtUtc),
				null,
				p.CreatedAtUtc));
		var fluent = _fluentHandler.Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IMongoDbFluent<PostLike, PostLikeId> Match(FilterDefinition<PostLike> filterDefinition)
	{
		_fluentHandler.Match(filterDefinition);

		return this;
	}

	public async Task<PostLike?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<long> GetCountAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetCountAsync(cancellationToken);
	}

	public async Task<ICollection<PostLike>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}

	public async Task<bool> AnyAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.AnyAsync(cancellationToken);
	}

	public async Task<ICollection<PostLikeId>> GetIdsAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetIdsAsync(cancellationToken);
	}
}
