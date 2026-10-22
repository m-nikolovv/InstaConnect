namespace InstaConnect.Chats.Events.Features.Chats.Models;

public record ChatEventRequest(
		string ParticipantOneId,
		string ParticipantTwoId,
		UserEventRequest ParticipantOne,
		UserEventRequest ParticipantTwo,
		DateTimeOffset CreatedAtUtc);
