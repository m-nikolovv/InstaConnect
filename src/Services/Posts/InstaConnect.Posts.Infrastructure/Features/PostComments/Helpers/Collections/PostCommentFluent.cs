using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.PostImages.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentFluent : MongoDbFluent<PostComment>, IPostCommentFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostCommentIncluderFactory _includerFactory;
	private readonly IPostCommentsSortTermerFactory _sortTermerFactory;
	private readonly IPostCommentIncludeBuilderFactory _includeBuilderFactory;
	private readonly IPostCommentResponseFluentFactory _responseFluentFactory;
	private readonly IPostCommentsForUserSortTermerFactory _forUserSortTermerFactory;

	public PostCommentFluent(
		IAggregateFluent<PostComment> fluent,
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostCommentIncluderFactory includerFactory,
		IPostCommentsSortTermerFactory sortTermerFactory,
		IPostCommentIncludeBuilderFactory includeBuilderFactory,
		IPostCommentResponseFluentFactory responseFluentFactory,
		IPostCommentsForUserSortTermerFactory forUserSortTermerFactory) : base(fluent)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_includeBuilderFactory = includeBuilderFactory;
		_responseFluentFactory = responseFluentFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostCommentFluent ApplyIncludes(PostCommentInclude include)
	{
		ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IPostCommentFluent Match(PostCommentsFilterQuery filter)
	{
		ApplyUserInclude();

		Match(filter.GetFilter());

		return this;
	}

	public IPostCommentFluent Match(PostCommentsForUserFilterQuery filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IPostCommentFluent Match(PostCommentId filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IPostCommentFluent ApplySorting(PostCommentsSortingQuery query)
	{
		if (query.Term == PostCommentsSortTerm.ByUserName)
		{
			ApplyUserInclude();
		}

		ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IPostCommentFluent ApplySorting(PostCommentsForUserSortingQuery query)
	{
		if (query.Term == PostCommentsForUserSortTerm.ByUserName)
		{
			ApplyUserInclude();
		}

		ApplySorting(_sortOrdererFactory, _forUserSortTermerFactory, query);

		return this;
	}

	public IPostCommentFluent ApplyPagination(PostCommentsPaginationQuery query)
	{
		ApplyPagination(_paginator, query);

		return this;
	}

	public IPostCommentResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id?.ToLower();
		var projection = Builders<PostComment>.Projection.Expression(
			p => new PostCommentResponse(
				p.Id,
				p.UserId,
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
				p.PostCommentImages.Select(
					pi => new PostCommentImageResponse(
						pi.Id,
						pi.Url,
						pi.CreatedAtUtc)).ToList(),
				p.PostCommentLikes.Any(
							pl => pl.Id.UserId.Id.ToLower() == currentUserId),
				p.PostCommentLikes.Count,
				p.CreatedAtUtc,
				p.UpdatedAtUtc));
		var fluent = Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IPostCommentResponseFluent ProjectToResponseWithoutUser(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id?.ToLower();
		var projection = Builders<PostComment>.Projection.Expression(
			p => new PostCommentResponse(
				p.Id,
				p.UserId,
				p.Content,
				p.Summary,
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
				p.PostCommentImages.Select(
					pi => new PostCommentImageResponse(
						pi.Id,
						pi.Url,
						pi.CreatedAtUtc)).ToList(),
				p.PostCommentLikes.Any(
							pl => pl.Id.UserId.Id.ToLower() == currentUserId),
				p.PostCommentLikes.Count,
				p.CreatedAtUtc,
				p.UpdatedAtUtc));
		var fluent = Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IPostCommentResponseFluent ProjectToResponseWithoutPost(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id?.ToLower();
		var projection = Builders<PostComment>.Projection.Expression(
			p => new PostCommentResponse(
				p.Id,
				p.UserId,
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
				null,
				p.PostCommentImages.Select(
					pi => new PostCommentImageResponse(
						pi.Id,
						pi.Url,
						pi.CreatedAtUtc)).ToList(),
				p.PostCommentLikes.Any(
							pl => pl.Id.UserId.Id.ToLower() == currentUserId),
				p.PostCommentLikes.Count,
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
