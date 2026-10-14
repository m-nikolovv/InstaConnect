using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenTest : BaseTest
{
	protected IPasswordHasher PasswordHasher { get; }
	protected string Password { get; }
	protected DateTimeOffset ExpiredDate { get; }
	protected DateTimeOffset UnexpiredDate { get; }

	protected UserBuilderFactory UserBuilderFactory { get; }
	protected UserBuilder UserBuilder { get; }
	protected User User { get; }
	protected ICollection<User> Users { get; }

	protected UserClaimBuilderFactory UserClaimBuilderFactory { get; }
	protected UserClaimBuilder UserClaimBuilder { get; }
	protected UserClaim UserClaim { get; }
	protected ICollection<UserClaim> UserClaims { get; }

	protected EmailConfirmationTokenBuilderFactory EmailConfirmationTokenBuilderFactory { get; }
	protected EmailConfirmationTokenBuilder EmailConfirmationTokenBuilder { get; }
	protected EmailConfirmationToken EmailConfirmationToken { get; }
	protected ICollection<EmailConfirmationToken> EmailConfirmationTokens { get; }

	protected CancellationToken CancellationToken { get; }

	protected BaseEmailConfirmationTokenTest(IPasswordHasher passwordHasher)
	{
		PasswordHasher = passwordHasher;
		Password = UserDataFaker.GetPassword();

		UserBuilderFactory = new();
		UserBuilder = UserBuilderFactory.Create(PasswordHasher.Hash(Password));
		User = UserBuilder.WithUnconfirmedEmail().Build();
		Users = User.Generate();

		UserClaimBuilderFactory = new();
		UserClaimBuilder = UserClaimBuilderFactory.Create(User);
		UserClaim = UserClaimBuilder.Build();
		UserClaims = UserClaim.Generate(Users);

		EmailConfirmationTokenBuilderFactory = new();
		EmailConfirmationTokenBuilder = EmailConfirmationTokenBuilderFactory.Create(User);
		EmailConfirmationToken = EmailConfirmationTokenBuilder.Build();
		EmailConfirmationTokens = EmailConfirmationToken.Generate(Users);

		ExpiredDate = EmailConfirmationTokenDataFaker.GetExpired(EmailConfirmationToken.ExpiresAtUtc);
		UnexpiredDate = EmailConfirmationTokenDataFaker.GetUnexpired(EmailConfirmationToken.ExpiresAtUtc);

		CancellationToken = MockFactory.CreateCancellationToken();
	}
}
