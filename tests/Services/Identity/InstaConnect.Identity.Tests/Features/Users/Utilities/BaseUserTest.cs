using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public abstract class BaseUserTest : BaseTest
{
	protected IPasswordHasher PasswordHasher { get; }
	protected string Password { get; }

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

	protected BaseUserTest(IPasswordHasher passwordHasher)
	{
		PasswordHasher = passwordHasher;
		Password = UserDataFaker.GetPassword();

		UserBuilderFactory = new();
		UserBuilder = UserBuilderFactory.Create(PasswordHasher.Hash(Password));
		User = UserBuilder.Build();
		Users = User.Generate();

		UserIdBuilderFactory = new();
		UserIdBuilder = UserIdBuilderFactory.Create(User.Id);
		UserId = UserIdBuilder.Build();

		UserIdRangeBuilderFactory = new();
		UserIdRangeBuilder = UserIdRangeBuilderFactory.Create([.. Users.Select(u => u.Id)]);
		UserIds = UserIdRangeBuilder.Build();

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
	}
}
