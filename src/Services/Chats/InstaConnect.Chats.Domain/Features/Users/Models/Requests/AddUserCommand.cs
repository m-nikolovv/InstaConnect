namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record AddUserCommand(
	UserId Id,
	string FirstName,
	string LastName,
	Name Name,
	Email Email,
	Url? ProfileImageUrl,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
