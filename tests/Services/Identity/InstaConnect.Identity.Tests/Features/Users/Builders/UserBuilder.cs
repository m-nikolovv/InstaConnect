using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.Users.Builders;

public class UserBuilder
{
	private string _id;
	private readonly string _name;
	private readonly string _firstName;
	private readonly string _lastName;
	private readonly string _email;
	private bool _isEmailConfirmed;
	private string _passwordHash;
	private readonly string? _profileImage;
	private readonly ICollection<UserClaim> _userClaims;
	private readonly ICollection<RefreshToken> _refreshTokens;
	private readonly ICollection<EmailConfirmationToken> _emailConfirmationTokens;
	private readonly ICollection<ForgotPasswordToken> _forgotPasswordTokens;
	private readonly DateTimeOffset _createdAtUtc;
	private readonly DateTimeOffset _updatedAtUtc;

	public UserBuilder(string passwordHash)
	{
		_id = UserDataFaker.GetId();
		_name = UserDataFaker.GetName();
		_firstName = UserDataFaker.GetFirstName();
		_lastName = UserDataFaker.GetLastName();
		_email = UserDataFaker.GetEmail();
		_isEmailConfirmed = UserDataFaker.GetIsEmailConfirmed();
		_passwordHash = passwordHash;
		_profileImage = UserDataFaker.GetProfileImageUrl();
		_userClaims = [];
		_refreshTokens = [];
		_emailConfirmationTokens = [];
		_forgotPasswordTokens = [];
		_createdAtUtc = UserDataFaker.GetCreatedAtUtc();
		_updatedAtUtc = _createdAtUtc;
	}

	public UserBuilder(User user)
	{
		_id = user.Id.Id;
		_name = user.Name.Value;
		_firstName = user.FirstName;
		_lastName = user.LastName;
		_email = user.Email.Value;
		_isEmailConfirmed = user.IsEmailConfirmed;
		_passwordHash = user.PasswordHash;
		_profileImage = user.ProfileImageUrl?.Value;
		_userClaims = [.. user.UserClaims];
		_refreshTokens = [.. user.RefreshTokens];
		_emailConfirmationTokens = [.. user.EmailConfirmationTokens];
		_forgotPasswordTokens = [.. user.ForgotPasswordTokens];
		_createdAtUtc = user.CreatedAtUtc;
		_updatedAtUtc = user.UpdatedAtUtc;
	}

	public UserBuilder WithId(UserId id)
	{
		_id = id.Id;

		return this;
	}

	public UserBuilder WithPasswordHash(string passwordHash)
	{
		_passwordHash = passwordHash;

		return this;
	}

	public UserBuilder WithConfirmedEmail()
	{
		_isEmailConfirmed = true;

		return this;
	}

	public UserBuilder WithUnconfirmedEmail()
	{
		_isEmailConfirmed = false;

		return this;
	}

	public User Build()
	{
		var user = new User(
			new(_id),
			_firstName,
			_lastName,
			new(_email),
			new(_name),
			_passwordHash,
			_isEmailConfirmed,
			_profileImage == null ? null : new(_profileImage),
			_createdAtUtc,
			_updatedAtUtc);

		user.AddUserClaims(_userClaims);
		user.AddRefreshTokens(_refreshTokens);
		user.AddEmailConfirmationTokens(_emailConfirmationTokens);
		user.AddForgotPasswordTokens(_forgotPasswordTokens);

		return user;
	}
}
