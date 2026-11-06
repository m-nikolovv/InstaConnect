using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Tests.Features.UserClaims.Builders;

namespace InstaConnect.Identity.Tests.Features.Common.Utilities;

public abstract class BaseIdentityTest : BaseTest
{
	protected IPasswordHasher PasswordHasher { get; }
	protected string Password { get; }
	protected string NewPassword { get; }

	protected DateTimeOffset RefreshTokenExpiredDate { get; }
	protected DateTimeOffset RefreshTokenUnexpiredDate { get; }

	protected DateTimeOffset ForgotPasswordTokenExpiredDate { get; }
	protected DateTimeOffset ForgotPasswordTokenUnexpiredDate { get; }

	protected DateTimeOffset EmailConfirmationTokenExpiredDate { get; }
	protected DateTimeOffset EmailConfirmationTokenUnexpiredDate { get; }

	protected UserBuilderFactory UserBuilderFactory { get; }
	protected UserBuilder UserBuilder { get; }
	protected User User { get; }
	protected ICollection<User> Users { get; }

	protected UserIdBuilderFactory UserIdBuilderFactory { get; }
	protected UserIdBuilder UserIdBuilder { get; }
	protected UserId UserId { get; }

	protected UserIdRangeBuilderFactory UserIdRangeBuilderFactory { get; }
	protected UserIdRangeBuilder UserIdRangeBuilder { get; }
	protected ICollection<UserId> UserIds { get; }

	protected UserClaimBuilderFactory UserClaimBuilderFactory { get; }
	protected UserClaimBuilder UserClaimBuilder { get; }
	protected UserClaim UserClaim { get; }
	protected ICollection<UserClaim> UserClaims { get; }

	protected UserClaimIdBuilderFactory UserClaimIdBuilderFactory { get; }
	protected UserClaimIdBuilder UserClaimIdBuilder { get; }
	protected UserClaimId UserClaimId { get; }

	protected UserClaimIdRangeBuilderFactory UserClaimIdRangeBuilderFactory { get; }
	protected UserClaimIdRangeBuilder UserClaimIdRangeBuilder { get; }
	protected ICollection<UserClaimId> UserClaimIds { get; }

	protected RefreshTokenBuilderFactory RefreshTokenBuilderFactory { get; }
	protected RefreshTokenBuilder RefreshTokenBuilder { get; }
	protected RefreshToken RefreshToken { get; }
	protected ICollection<RefreshToken> RefreshTokens { get; }

	protected RefreshTokenIdBuilderFactory RefreshTokenIdBuilderFactory { get; }
	protected RefreshTokenIdBuilder RefreshTokenIdBuilder { get; }
	protected RefreshTokenId RefreshTokenId { get; }

	protected RefreshTokenIdRangeBuilderFactory RefreshTokenIdRangeBuilderFactory { get; }
	protected RefreshTokenIdRangeBuilder RefreshTokenIdRangeBuilder { get; }
	protected ICollection<RefreshTokenId> RefreshTokenIds { get; }

	protected ForgotPasswordTokenBuilderFactory ForgotPasswordTokenBuilderFactory { get; }
	protected ForgotPasswordTokenBuilder ForgotPasswordTokenBuilder { get; }
	protected ForgotPasswordToken ForgotPasswordToken { get; }
	protected ICollection<ForgotPasswordToken> ForgotPasswordTokens { get; }

	protected ForgotPasswordTokenIdBuilderFactory ForgotPasswordTokenIdBuilderFactory { get; }
	protected ForgotPasswordTokenIdBuilder ForgotPasswordTokenIdBuilder { get; }
	protected ForgotPasswordTokenId ForgotPasswordTokenId { get; }

	protected ForgotPasswordTokenIdRangeBuilderFactory ForgotPasswordTokenIdRangeBuilderFactory { get; }
	protected ForgotPasswordTokenIdRangeBuilder ForgotPasswordTokenIdRangeBuilder { get; }
	protected ICollection<ForgotPasswordTokenId> ForgotPasswordTokenIds { get; }

	protected EmailConfirmationTokenBuilderFactory EmailConfirmationTokenBuilderFactory { get; }
	protected EmailConfirmationTokenBuilder EmailConfirmationTokenBuilder { get; }
	protected EmailConfirmationToken EmailConfirmationToken { get; }
	protected ICollection<EmailConfirmationToken> EmailConfirmationTokens { get; }

	protected EmailConfirmationTokenIdBuilderFactory EmailConfirmationTokenIdBuilderFactory { get; }
	protected EmailConfirmationTokenIdBuilder EmailConfirmationTokenIdBuilder { get; }
	protected EmailConfirmationTokenId EmailConfirmationTokenId { get; }

	protected EmailConfirmationTokenIdRangeBuilderFactory EmailConfirmationTokenIdRangeBuilderFactory { get; }
	protected EmailConfirmationTokenIdRangeBuilder EmailConfirmationTokenIdRangeBuilder { get; }
	protected ICollection<EmailConfirmationTokenId> EmailConfirmationTokenIds { get; }

	protected BaseIdentityTest(IPasswordHasher passwordHasher, bool isEmailConfirmed = true)
	{
		PasswordHasher = passwordHasher;
		Password = UserDataFaker.GetPassword();
		NewPassword = UserDataFaker.GetPassword();

		UserBuilderFactory = new();
		UserBuilder = UserBuilderFactory.Create(PasswordHasher.Hash(Password));
		User = isEmailConfirmed ? UserBuilder.Build() : UserBuilder.WithUnconfirmedEmail().Build();
		Users = User.Generate();

		UserIdBuilderFactory = new();
		UserIdBuilder = UserIdBuilderFactory.Create(User.Id);
		UserId = UserIdBuilder.Build();

		UserIdRangeBuilderFactory = new();
		UserIdRangeBuilder = UserIdRangeBuilderFactory.Create([.. Users.Select(u => u.Id)]);
		UserIds = UserIdRangeBuilder.Build();

		UserClaimBuilderFactory = new();
		UserClaimBuilder = UserClaimBuilderFactory.Create(User);
		UserClaim = UserClaimBuilder.Build();
		UserClaims = UserClaim.Generate(Users);

		UserClaimIdBuilderFactory = new();
		UserClaimIdBuilder = UserClaimIdBuilderFactory.Create(UserClaim.Id);
		UserClaimId = UserClaimIdBuilder.Build();

		UserClaimIdRangeBuilderFactory = new();
		UserClaimIdRangeBuilder = UserClaimIdRangeBuilderFactory.Create([.. UserClaims.Select(u => u.Id)]);
		UserClaimIds = UserClaimIdRangeBuilder.Build();

		RefreshTokenBuilderFactory = new();
		RefreshTokenBuilder = RefreshTokenBuilderFactory.Create(User);
		RefreshToken = RefreshTokenBuilder.Build();
		RefreshTokens = RefreshToken.Generate(Users);

		RefreshTokenIdBuilderFactory = new();
		RefreshTokenIdBuilder = RefreshTokenIdBuilderFactory.Create(RefreshToken.Id);
		RefreshTokenId = RefreshTokenIdBuilder.Build();

		RefreshTokenIdRangeBuilderFactory = new();
		RefreshTokenIdRangeBuilder = RefreshTokenIdRangeBuilderFactory.Create([.. RefreshTokens.Select(r => r.Id)]);
		RefreshTokenIds = RefreshTokenIdRangeBuilder.Build();

		ForgotPasswordTokenBuilderFactory = new();
		ForgotPasswordTokenBuilder = ForgotPasswordTokenBuilderFactory.Create(User);
		ForgotPasswordToken = ForgotPasswordTokenBuilder.Build();
		ForgotPasswordTokens = ForgotPasswordToken.Generate(Users);

		ForgotPasswordTokenIdBuilderFactory = new();
		ForgotPasswordTokenIdBuilder = ForgotPasswordTokenIdBuilderFactory.Create(ForgotPasswordToken.Id);
		ForgotPasswordTokenId = ForgotPasswordTokenIdBuilder.Build();

		ForgotPasswordTokenIdRangeBuilderFactory = new();
		ForgotPasswordTokenIdRangeBuilder = ForgotPasswordTokenIdRangeBuilderFactory.Create([.. ForgotPasswordTokens.Select(f => f.Id)]);
		ForgotPasswordTokenIds = ForgotPasswordTokenIdRangeBuilder.Build();

		EmailConfirmationTokenBuilderFactory = new();
		EmailConfirmationTokenBuilder = EmailConfirmationTokenBuilderFactory.Create(User);
		EmailConfirmationToken = EmailConfirmationTokenBuilder.Build();
		EmailConfirmationTokens = EmailConfirmationToken.Generate(Users);

		EmailConfirmationTokenIdBuilderFactory = new();
		EmailConfirmationTokenIdBuilder = EmailConfirmationTokenIdBuilderFactory.Create(EmailConfirmationToken.Id);
		EmailConfirmationTokenId = EmailConfirmationTokenIdBuilder.Build();

		EmailConfirmationTokenIdRangeBuilderFactory = new();
		EmailConfirmationTokenIdRangeBuilder = EmailConfirmationTokenIdRangeBuilderFactory.Create([.. EmailConfirmationTokens.Select(e => e.Id)]);
		EmailConfirmationTokenIds = EmailConfirmationTokenIdRangeBuilder.Build();

		RefreshTokenExpiredDate = RefreshTokenDataFaker.GetExpired(RefreshToken.ExpiresAtUtc);
		RefreshTokenUnexpiredDate = RefreshTokenDataFaker.GetUnexpired(RefreshToken.ExpiresAtUtc);

		ForgotPasswordTokenExpiredDate = ForgotPasswordTokenDataFaker.GetExpired(ForgotPasswordToken.ExpiresAtUtc);
		ForgotPasswordTokenUnexpiredDate = ForgotPasswordTokenDataFaker.GetUnexpired(ForgotPasswordToken.ExpiresAtUtc);

		EmailConfirmationTokenExpiredDate = EmailConfirmationTokenDataFaker.GetExpired(EmailConfirmationToken.ExpiresAtUtc);
		EmailConfirmationTokenUnexpiredDate = EmailConfirmationTokenDataFaker.GetUnexpired(EmailConfirmationToken.ExpiresAtUtc);
	}
}
