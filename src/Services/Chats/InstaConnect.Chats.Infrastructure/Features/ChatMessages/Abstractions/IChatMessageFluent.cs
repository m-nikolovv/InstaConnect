namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageFluent : IMongoDbFluent<ChatMessage, ChatMessageId>
{
	public IChatMessageFluent Match(ChatMessagesFilterQuery filter);
	public IChatMessageFluent Match(ChatMessageId filter);
	public IChatMessageFluent Match(IEnumerable<ChatMessageId> filter);
	public IChatMessageResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser);
	public IChatMessageResponseFluent ProjectToResponseWithoutChat(CurrentUserQuery currentUser);
	public IChatMessageResponseFluent ProjectToResponseWithoutSender(CurrentUserQuery currentUser);
	public IChatMessageFluent Include(ChatMessageInclude include);
}
