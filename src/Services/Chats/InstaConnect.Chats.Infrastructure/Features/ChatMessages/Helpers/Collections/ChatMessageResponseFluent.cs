namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

internal class ChatMessageResponseFluent : IChatMessageResponseFluent
{
	private readonly IMongoDbResponseFluentHandler<ChatMessageResponse> _fluentHandler;

	public ChatMessageResponseFluent(IMongoDbResponseFluentHandler<ChatMessageResponse> fluentHandler)
	{
		_fluentHandler = fluentHandler;
	}

	public async Task<ChatMessageResponse?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<ChatMessageResponse>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}
}
