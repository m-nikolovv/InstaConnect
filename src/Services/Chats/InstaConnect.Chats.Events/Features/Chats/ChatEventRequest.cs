namespace InstaConnect.Chats.Events.Features.Chats;

public record ChatEventRequest(
		string ParticipantOneId,
		string ParticipantTwoId,
		UserEventRequest ParticipantOne,
		UserEventRequest ParticipantTwo,
		DateTimeOffset CreatedAtUtc);
