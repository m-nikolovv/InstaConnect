
namespace InstaConnect.Chats.Domain.Features.Chats.Models.Responses;

public record ChatResponse(
	ChatId Id,
	UserResponse? ParticipantOne,
	UserResponse? ParticipantTwo,
	int MessageCount,
	DateTimeOffset CreatedAtUtc) : IEntityResponse
{
	public bool IsNotParticipant(UserId participantId)
	{
		return Id.ParticipantOneId.IsNot(participantId) || Id.ParticipantTwoId.IsNot(participantId);
	}
}
