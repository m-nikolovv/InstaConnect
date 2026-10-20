using InstaConnect.Posts.Domain.Features.PostImages.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeFluent : MongoDbFluent<PostLike>, IPostLikeFluent
{
	private readonly IPostLikeIncluderFactory _includerFactory;
	private readonly IPostLikeResponseFluentFactory _responseFluentFactory;

	public PostLikeFluent(
		IAggregateFluent<PostLike> fluent,
		IPostLikeIncluderFactory includerFactory,
		IPostLikeResponseFluentFactory responseFluentFactory) : base(fluent)
	{
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IPostLikeFluent ApplyIncludes(PostLikeInclude include)
	{
		ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IPostLikeFluent Match(PostLikesFilterQuery filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IPostLikeFluent Match(PostLikesForUserFilterQuery filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IPostLikeFluent Match(PostLikeId filter)
	{
		Match(filter.GetFilter());

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
					p.Post.CreatedAtUtc,
					p.Post.UpdatedAtUtc),
				p.CreatedAtUtc));
		var fluent = Project(projection);

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
					p.Post.CreatedAtUtc,
					p.Post.UpdatedAtUtc),
				p.CreatedAtUtc));
		var fluent = Project(projection);

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
		var fluent = Project(projection);

		return _responseFluentFactory.Create(fluent);
	}
}
