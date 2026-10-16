using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostFluent : MongoDbFluent<Post>, IPostFluent
{
	private readonly IPostIncluderFactory _includerFactory;
	private readonly IPostResponseFluentFactory _responseFluentFactory;

	public PostFluent(
		IAggregateFluent<Post> fluent,
		IPostIncluderFactory includerFactory,
		IPostResponseFluentFactory responseFluentFactory) : base(fluent)
	{
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IPostFluent ApplyIncludes(PostInclude include)
	{
		ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IPostFluent Match(PostsFilterQuery filter)
	{
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

	public IPostResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id?.ToLower();
		var projection = Builders<Post>.Projection.Expression(
			 p => new PostResponse(
				 p.Id,
				 p.UserId,
				 p.Title,
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
				 p.PostLikes.Any(
					 pl => pl.Id.UserId.Id.ToLower() == currentUserId),
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
				 null,
				 p.PostLikes.Any(
					 pl => pl.Id.UserId.Id.ToLower() == currentUserId),
				 p.CreatedAtUtc,
				 p.UpdatedAtUtc));
		var fluent = Project(projection);

		return _responseFluentFactory.Create(fluent);
	}
}
