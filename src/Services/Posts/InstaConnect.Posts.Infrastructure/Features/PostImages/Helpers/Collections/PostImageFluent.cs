using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Collections;

internal class PostImageFluent : IPostImageFluent
{
	private readonly IMongoDbFluentHandler<PostImage, PostImageId> _fluentHandler;

	public PostImageFluent(IMongoDbFluentHandler<PostImage, PostImageId> fluentHandler)
	{
		_fluentHandler = fluentHandler;
	}

	public IPostImageFluent Match(PostImageId filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IPostImageFluent Match(IEnumerable<PostImageId> filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IMongoDbFluent<PostImage, PostImageId> Match(FilterDefinition<PostImage> filterDefinition)
	{
		_fluentHandler.Match(filterDefinition);

		return this;
	}

	public async Task<PostImage?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<long> GetCountAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetCountAsync(cancellationToken);
	}

	public async Task<ICollection<PostImage>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}

	public async Task<bool> AnyAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.AnyAsync(cancellationToken);
	}

	public async Task<ICollection<PostImageId>> GetIdsAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetIdsAsync(cancellationToken);
	}
}
