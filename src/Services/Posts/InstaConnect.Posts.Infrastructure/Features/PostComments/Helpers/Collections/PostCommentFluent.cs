using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostImages.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentFluent : IPostCommentFluent
{
	private readonly IPostCommentIncluderFactory _includerFactory;
	private readonly IPostCommentResponseFluentFactory _responseFluentFactory;
	private readonly IMongoDbFluentHandler<PostComment, PostCommentId> _fluentHandler;

	public PostCommentFluent(
		IPostCommentIncluderFactory includerFactory,
		IPostCommentResponseFluentFactory responseFluentFactory,
		IMongoDbFluentHandler<PostComment, PostCommentId> fluentHandler)
	{
		_fluentHandler = fluentHandler;
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IPostCommentFluent Include(PostCommentInclude include)
	{
		_fluentHandler.Include(_includerFactory, include);

		return this;
	}

	public IPostCommentFluent Match(PostCommentsFilterQuery filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IPostCommentFluent Match(PostCommentsForUserFilterQuery filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IPostCommentFluent Match(PostCommentId filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IPostCommentFluent Match(IEnumerable<PostCommentId> filter)
	{
		_fluentHandler.Match(filter.GetFilter());

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
		var fluent = _fluentHandler.Project(projection);

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
		var fluent = _fluentHandler.Project(projection);

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
		var fluent = _fluentHandler.Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IMongoDbFluent<PostComment, PostCommentId> Match(FilterDefinition<PostComment> filterDefinition)
	{
		_fluentHandler.Match(filterDefinition);

		return this;
	}

	public async Task<PostComment?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<long> GetCountAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetCountAsync(cancellationToken);
	}

	public async Task<ICollection<PostComment>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}

	public async Task<bool> AnyAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.AnyAsync(cancellationToken);
	}

	public async Task<ICollection<PostCommentId>> GetIdsAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetIdsAsync(cancellationToken);
	}
}
