using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentFluent : MongoDbFluent<PostComment>, IPostCommentFluent
{
	private readonly IPostCommentIncluderFactory _includerFactory;
	private readonly IPostCommentResponseFluentFactory _responseFluentFactory;

	public PostCommentFluent(
		IAggregateFluent<PostComment> fluent,
		IPostCommentIncluderFactory includerFactory,
		IPostCommentResponseFluentFactory responseFluentFactory) : base(fluent)
	{
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IPostCommentFluent ApplyIncludes(PostCommentInclude include)
	{
		ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IPostCommentFluent Match(PostCommentsFilterQuery filter)
	{
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

	public IPostCommentResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id?.ToLower();
		var projection = Builders<PostComment>.Projection.Expression(
			p => new PostCommentResponse(
				p.Id,
				p.UserId,
				p.Content,
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
					p.Post.CreatedAtUtc,
					p.Post.UpdatedAtUtc),
				p.PostCommentLikes.Any(
							pl => pl.Id.UserId.Id.ToLower() == currentUserId),
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
					p.Post.CreatedAtUtc,
					p.Post.UpdatedAtUtc),
				p.PostCommentLikes.Any(
							pl => pl.Id.UserId.Id.ToLower() == currentUserId),
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
				p.PostCommentLikes.Any(
							pl => pl.Id.UserId.Id.ToLower() == currentUserId),
				p.CreatedAtUtc,
				p.UpdatedAtUtc));
		var fluent = Project(projection);

		return _responseFluentFactory.Create(fluent);
	}
}
