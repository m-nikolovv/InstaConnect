namespace InstaConnect.Posts.Domain.Features.Users.Models.Responses;

public record UserResponse(
	UserId Id,
	string FirstName,
	string LastName,
	Email Email,
	Name Name,
	Url? ProfileImageUrl,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc) : IEntityResponse;
