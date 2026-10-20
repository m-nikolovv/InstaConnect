namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public static class UserGenerator
{
	extension(User baseUser)
	{
		public ICollection<User> Generate(int numberOfIterations = 5)
		{
			return [baseUser, .. Enumerable.Range(default, numberOfIterations)
			.Select(_ => new User(new(UserDataFaker.GetId()),
								  UserDataFaker.GetFirstNameWithPrefix(baseUser.FirstName),
								  UserDataFaker.GetLastNameWithPrefix(baseUser.LastName),
								  new(UserDataFaker.GetEmailWithPrefix(baseUser.Email.Value)),
								  new(UserDataFaker.GetNameWithPrefix(baseUser.Name.Value)),
								  baseUser.PasswordHash,
								  baseUser.IsEmailConfirmed,
								  baseUser.ProfileImageUrl,
								  UserDataFaker.GetCreatedAtUtc(),
								  UserDataFaker.GetUpdatedAtUtc()))];
		}
	}
}
