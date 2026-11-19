using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Collections;

internal class PostCommentImageFluent : IPostCommentImageFluent
{
	private readonly IMongoDbFluentHandler<PostCommentImage, PostCommentImageId> _fluentHandler;

	public PostCommentImageFluent(IMongoDbFluentHandler<PostCommentImage, PostCommentImageId> fluentHandler)
	{
		_fluentHandler = fluentHandler;
	}

	public IPostCommentImageFluent Match(PostCommentImageId filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IPostCommentImageFluent Match(IEnumerable<PostCommentImageId> filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IMongoDbFluent<PostCommentImage, PostCommentImageId> Match(FilterDefinition<PostCommentImage> filterDefinition)
	{
		_fluentHandler.Match(filterDefinition);

		return this;
	}

	public async Task<PostCommentImage?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<long> GetCountAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetCountAsync(cancellationToken);
	}

	public async Task<ICollection<PostCommentImage>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}

	public async Task<bool> AnyAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.AnyAsync(cancellationToken);
	}

	public async Task<ICollection<PostCommentImageId>> GetIdsAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetIdsAsync(cancellationToken);
	}
}
