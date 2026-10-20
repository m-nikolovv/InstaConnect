namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record UpdateUserCommand(
	UserId Id,
	string FirstName,
	string LastName,
	Name Name,
	Email Email,
	Url? ProfileImageUrl,
	DateTimeOffset UpdatedAtUtc);
