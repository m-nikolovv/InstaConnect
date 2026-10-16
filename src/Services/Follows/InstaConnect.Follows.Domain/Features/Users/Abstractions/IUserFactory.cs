namespace InstaConnect.Follows.Domain.Features.Users.Abstractions;

public interface IUserFactory
{
	public User Create(
		UserId id,
		string firstName,
		string lastName,
		Name name,
		Email email,
		Url? profileImageUrl,
		DateTimeOffset createdAtUtc,
		DateTimeOffset updatedAtUtc);
}
