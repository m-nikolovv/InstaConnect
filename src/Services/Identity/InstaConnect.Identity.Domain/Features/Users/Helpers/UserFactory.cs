using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;

namespace InstaConnect.Identity.Domain.Features.Users.Helpers;

internal class UserFactory : IUserFactory
{
	private readonly IGuidProvider _guidProvider;
	private readonly IPasswordHasher _passwordHasher;
	private readonly IDateTimeProvider _dateTimeProvider;

	public UserFactory(
		IGuidProvider guidProvider,
		IPasswordHasher passwordHasher,
		IDateTimeProvider dateTimeProvider)
	{
		_guidProvider = guidProvider;
		_passwordHasher = passwordHasher;
		_dateTimeProvider = dateTimeProvider;
	}

	public User Create(
		Name name,
		string firstName,
		string lastName,
		Email email,
		string password)
	{
		var id = _guidProvider.NewStringGuid();
		var passwordHash = _passwordHasher.Hash(password);
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var user = new User(
			new(id),
			firstName,
			lastName,
			email,
			name,
			passwordHash,
			false,
			null,
			utcNow,
			utcNow);

		return user;
	}
}
