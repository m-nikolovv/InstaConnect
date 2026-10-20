namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.SortTermers;

internal class ByParticipantTwoNameSortTermer : IChatsSortTermer
{
	public ChatsSortTerm SortTerm => ChatsSortTerm.ByParticipantTwoName;

	public Expression<Func<ChatResponse, object>> Term => p => p.ParticipantTwo!.Name.Value;
}
