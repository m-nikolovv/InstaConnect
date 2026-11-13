using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Collections;

internal class ChatMessageImageFluent : IChatMessageImageFluent
{
	private readonly IMongoDbFluentHandler<ChatMessageImage, ChatMessageImageId> _fluentHandler;

	public ChatMessageImageFluent(IMongoDbFluentHandler<ChatMessageImage, ChatMessageImageId> fluentHandler)
	{
		_fluentHandler = fluentHandler;
	}

	public IChatMessageImageFluent Match(ChatMessageImageId filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IChatMessageImageFluent Match(IEnumerable<ChatMessageImageId> filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IMongoDbFluent<ChatMessageImage, ChatMessageImageId> Match(FilterDefinition<ChatMessageImage> filterDefinition)
	{
		_fluentHandler.Match(filterDefinition);

		return this;
	}

	public async Task<ChatMessageImage?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<long> GetCountAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetCountAsync(cancellationToken);
	}

	public async Task<ICollection<ChatMessageImage>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}

	public async Task<bool> AnyAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.AnyAsync(cancellationToken);
	}

	public async Task<ICollection<ChatMessageImageId>> GetIdsAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetIdsAsync(cancellationToken);
	}
}
