namespace InstaConnect.Chats.Application.Features.Chats.Models;

public record ChatQueryResponse(
	string ParticipantOneId,
	string ParticipantTwoId,
	UserQueryResponse? ParticipantOne,
	UserQueryResponse? ParticipantTwo,
	int MessageCount,
	DateTimeOffset CreatedAtUtc);
