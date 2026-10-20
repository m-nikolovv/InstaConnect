namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatFluent : IMongoDbFluent<Chat>
{
	public IChatFluent Match(ChatsFilterQuery filter);
	public IChatFluent Match(ChatId filter);
	public IChatResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser);
	public IChatResponseFluent ProjectToResponseWithoutParticipantOne(CurrentUserQuery currentUser);
	public IChatResponseFluent ProjectToResponseWithoutParticipantTwo(CurrentUserQuery currentUser);
	public IChatFluent ApplyIncludes(ChatInclude include);
}
