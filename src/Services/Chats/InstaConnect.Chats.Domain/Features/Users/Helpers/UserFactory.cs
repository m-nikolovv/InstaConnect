namespace InstaConnect.Chats.Domain.Features.Users.Helpers;

internal class UserFactory : IUserFactory
{
	public User Create(
		UserId id,
		string firstName,
		string lastName,
		Name name,
		Email email,
		Url? profileImageUrl,
		DateTimeOffset createdAtUtc,
		DateTimeOffset updatedAtUtc)
	{
		var user = new User(
			id,
			firstName,
			lastName,
			email,
			name,
			profileImageUrl,
			createdAtUtc,
			updatedAtUtc);

		return user;
	}
}
