namespace InstaConnect.Identity.Domain.Features.Users.Models.Entities;

public class User : IEntityWithId<UserId>
{
	private User()
	{
		Id = new(string.Empty);
		FirstName = string.Empty;
		LastName = string.Empty;
		Email = new(string.Empty);
		Name = new(string.Empty);
		PasswordHash = string.Empty;
		IsEmailConfirmed = false;
		UserClaims = [];
		RefreshTokens = [];
		ForgotPasswordTokens = [];
		EmailConfirmationTokens = [];
	}

	public User(
		UserId id,
		string firstName,
		string lastName,
		Email email,
		Name name,
		string passwordHash,
		bool isEmailConfirmed,
		Url? profileImageUrl,
		DateTimeOffset createdAtUtc,
		DateTimeOffset updatedAtUtc)
	{
		Id = id;
		FirstName = firstName;
		LastName = lastName;
		Email = email;
		Name = name;
		PasswordHash = passwordHash;
		IsEmailConfirmed = isEmailConfirmed;
		ProfileImageUrl = profileImageUrl;
		UserClaims = [];
		RefreshTokens = [];
		ForgotPasswordTokens = [];
		EmailConfirmationTokens = [];
		CreatedAtUtc = createdAtUtc;
		UpdatedAtUtc = updatedAtUtc;
	}

	public User(
		UserId id,
		string firstName,
		string lastName,
		Email email,
		Name name,
		string passwordHash,
		bool isEmailConfirmed,
		Url? profileImageUrl,
		DateTimeOffset createdAtUtc,
		DateTimeOffset updatedAtUtc,
		ICollection<UserClaim> userClaims,
		ICollection<RefreshToken> refreshTokens,
		ICollection<ForgotPasswordToken> forgotPasswordTokens,
		ICollection<EmailConfirmationToken> emailConfirmationTokens)
	{
		Id = id;
		FirstName = firstName;
		LastName = lastName;
		Email = email;
		Name = name;
		PasswordHash = passwordHash;
		IsEmailConfirmed = isEmailConfirmed;
		ProfileImageUrl = profileImageUrl;
		CreatedAtUtc = createdAtUtc;
		UpdatedAtUtc = updatedAtUtc;
		UserClaims = userClaims;
		RefreshTokens = refreshTokens;
		ForgotPasswordTokens = forgotPasswordTokens;
		EmailConfirmationTokens = emailConfirmationTokens;
	}

	public UserId Id { get; }

	public string FirstName { get; private set; }

	public string LastName { get; private set; }

	public Email Email { get; private set; }

	public Name Name { get; private set; }

	public string PasswordHash { get; private set; }

	public bool IsEmailConfirmed { get; private set; }

	public Url? ProfileImageUrl { get; private set; }

	public ICollection<UserClaim> UserClaims { get; private set; }

	public ICollection<RefreshToken> RefreshTokens { get; private set; }

	public ICollection<EmailConfirmationToken> EmailConfirmationTokens { get; private set; }

	public ICollection<ForgotPasswordToken> ForgotPasswordTokens { get; private set; }

	public DateTimeOffset CreatedAtUtc { get; }

	public DateTimeOffset UpdatedAtUtc { get; private set; }

	public bool IsEmailNotConfirmed => !IsEmailConfirmed;

	public void UpdateEmail(Email email)
	{
		Email = email;
		IsEmailConfirmed = false;
	}

	public void UpdateProfileImage(Url? profileImageUrl)
	{
		ProfileImageUrl = profileImageUrl;
	}

	public void ConfirmEmail()
	{
		IsEmailConfirmed = true;
	}

	public void UpdatePasswordHash(string passwordHash)
	{
		PasswordHash = passwordHash;
	}

	public void Update(
		string firstName,
		string lastName,
		Name name,
		DateTimeOffset updatedAtUtc)
	{
		FirstName = firstName;
		LastName = lastName;
		Name = name;
		UpdatedAtUtc = updatedAtUtc;
	}

	public User AddUserClaim(UserClaim userClaim)
	{
		UserClaims.Add(userClaim);

		return this;
	}

	public User AddRefreshToken(RefreshToken refreshToken)
	{
		RefreshTokens.Add(refreshToken);

		return this;
	}

	public User AddForgotPasswordToken(ForgotPasswordToken forgotPasswordToken)
	{
		ForgotPasswordTokens.Add(forgotPasswordToken);

		return this;
	}

	public User AddEmailConfirmationToken(EmailConfirmationToken emailConfirmationToken)
	{
		EmailConfirmationTokens.Add(emailConfirmationToken);

		return this;
	}
}


