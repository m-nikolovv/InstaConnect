using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Tests.Features.UserClaims.Builders;

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

	protected BaseEmailConfirmationTokenTest(IPasswordHasher passwordHasher)
	{
		PasswordHasher = passwordHasher;
		Password = UserDataFaker.GetPassword();

		UserBuilderFactory = new();
		UserBuilder = UserBuilderFactory.Create(PasswordHasher.Hash(Password));
		User = UserBuilder.WithUnconfirmedEmail().Build();
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

		ExpiredDate = EmailConfirmationTokenDataFaker.GetExpired(EmailConfirmationToken.ExpiresAtUtc);
		UnexpiredDate = EmailConfirmationTokenDataFaker.GetUnexpired(EmailConfirmationToken.ExpiresAtUtc);
	}
}
