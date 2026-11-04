namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageFluent : IMongoDbFluent<ChatMessage>
{
	public IChatMessageFluent Match(ChatMessagesFilterQuery filter);
	public IChatMessageFluent Match(ChatMessageId filter);
	public IChatMessageFluent ApplySorting(ChatMessagesSortingQuery query);
	public IChatMessageFluent ApplyPagination(ChatMessagesPaginationQuery query);
	public IChatMessageResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser);
	public IChatMessageResponseFluent ProjectToResponseWithoutChat(CurrentUserQuery currentUser);
	public IChatMessageResponseFluent ProjectToResponseWithoutSender(CurrentUserQuery currentUser);
	public IChatMessageFluent ApplyIncludes(ChatMessageInclude include);
}
