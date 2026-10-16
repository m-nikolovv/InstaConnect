using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeFluent : MongoDbFluent<PostCommentLike>, IPostCommentLikeFluent
{
	private readonly IPostCommentLikeIncluderFactory _includerFactory;
	private readonly IPostCommentLikeResponseFluentFactory _responseFluentFactory;

	public PostCommentLikeFluent(
		IAggregateFluent<PostCommentLike> fluent,
		IPostCommentLikeIncluderFactory includerFactory,
		IPostCommentLikeResponseFluentFactory responseFluentFactory) : base(fluent)
	{
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IPostCommentLikeFluent ApplyIncludes(PostCommentLikeInclude include)
	{
		ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IPostCommentLikeFluent Match(PostCommentLikesFilterQuery filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IPostCommentLikeFluent Match(PostCommentLikesForUserFilterQuery filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IPostCommentLikeFluent Match(PostCommentLikeId filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IPostCommentLikeResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id?.ToLower();
		var projection = Builders<PostCommentLike>.Projection
			.Expression(
			p => new PostCommentLikeResponse(
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
				new PostCommentResponse(
					p.PostComment!.Id,
					p.PostComment.UserId,
					p.PostComment.Content,
					   new UserResponse(
							p.PostComment.User!.Id,
							p.PostComment.User.FirstName,
							p.PostComment.User.LastName,
							p.PostComment.User.Email,
							p.PostComment.User.Name,
							p.PostComment.User.ProfileImageUrl,
							p.PostComment.User.CreatedAtUtc,
							p.PostComment.User.UpdatedAtUtc),
						new PostResponse(
							p.PostComment.Post!.Id,
							p.PostComment.Post.UserId,
							p.PostComment.Post.Title,
							p.PostComment.Post.Content,
								new UserResponse(
									p.PostComment.Post.User!.Id,
									p.PostComment.Post.User.FirstName,
									p.PostComment.Post.User.LastName,
									p.PostComment.Post.User.Email,
									p.PostComment.Post.User.Name,
									p.PostComment.Post.User.ProfileImageUrl,
									p.PostComment.Post.User.CreatedAtUtc,
									p.PostComment.Post.User.UpdatedAtUtc),
							p.PostComment.Post.PostImages.Select(
								pi => new PostImageResponse(
									pi.Id,
									pi.Url,
									pi.CreatedAtUtc)).ToList(),
							p.PostComment.Post.PostLikes != null && p.PostComment.Post.PostLikes.Any(
								pl => pl.Id.UserId.Id.ToLower() == currentUserId),
							p.PostComment.Post.CreatedAtUtc,
							p.PostComment.Post.UpdatedAtUtc),
					p.PostComment.PostCommentLikes != null && p.PostComment.PostCommentLikes.Any(
						pl => pl.Id.UserId.Id.ToLower() == currentUserId),
					p.PostComment.CreatedAtUtc,
					p.PostComment.UpdatedAtUtc),
				p.CreatedAtUtc));
		var fluent = Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IPostCommentLikeResponseFluent ProjectToResponseWithoutUser(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id?.ToLower();
		var projection = Builders<PostCommentLike>.Projection
			.Expression(
			p => new PostCommentLikeResponse(
				p.Id,
				null,
				new PostCommentResponse(
					p.PostComment!.Id,
					p.PostComment.UserId,
					p.PostComment.Content,
					   new UserResponse(
							p.PostComment.User!.Id,
							p.PostComment.User.FirstName,
							p.PostComment.User.LastName,
							p.PostComment.User.Email,
							p.PostComment.User.Name,
							p.PostComment.User.ProfileImageUrl,
							p.PostComment.User.CreatedAtUtc,
							p.PostComment.User.UpdatedAtUtc),
						new PostResponse(
							p.PostComment.Post!.Id,
							p.PostComment.Post.UserId,
							p.PostComment.Post.Title,
							p.PostComment.Post.Content,
								new UserResponse(
									p.PostComment.Post.User!.Id,
									p.PostComment.Post.User.FirstName,
									p.PostComment.Post.User.LastName,
									p.PostComment.Post.User.Email,
									p.PostComment.Post.User.Name,
									p.PostComment.Post.User.ProfileImageUrl,
									p.PostComment.Post.User.CreatedAtUtc,
									p.PostComment.Post.User.UpdatedAtUtc),
							p.PostComment.Post.PostImages.Select(
								pi => new PostImageResponse(
									pi.Id,
									pi.Url,
									pi.CreatedAtUtc)).ToList(),
							p.PostComment.Post.PostLikes != null && p.PostComment.Post.PostLikes.Any(
								pl => pl.Id.UserId.Id.ToLower() == currentUserId),
							p.PostComment.Post.CreatedAtUtc,
							p.PostComment.Post.UpdatedAtUtc),
					p.PostComment.PostCommentLikes != null && p.PostComment.PostCommentLikes.Any(
						pl => pl.Id.UserId.Id.ToLower() == currentUserId),
					p.PostComment.CreatedAtUtc,
					p.PostComment.UpdatedAtUtc),
				p.CreatedAtUtc));
		var fluent = Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IPostCommentLikeResponseFluent ProjectToResponseWithoutPostComment(CurrentUserQuery currentUser)
	{
		var projection = Builders<PostCommentLike>.Projection
			.Expression(
			p => new PostCommentLikeResponse(
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
		var fluent = Project(projection);

		return _responseFluentFactory.Create(fluent);
	}
}
