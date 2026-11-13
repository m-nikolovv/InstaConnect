using InstaConnect.Posts.Domain.Features.PostImages.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostFluent : IPostFluent
{
	private readonly IPostIncluderFactory _includerFactory;
	private readonly IPostResponseFluentFactory _responseFluentFactory;
	private readonly IMongoDbFluentHandler<Post, PostId> _fluentHandler;

	public PostFluent(
		IPostIncluderFactory includerFactory,
		IPostResponseFluentFactory responseFluentFactory,
		IMongoDbFluentHandler<Post, PostId> fluentHandler)
	{
		_fluentHandler = fluentHandler;
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
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
