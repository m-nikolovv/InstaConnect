using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public abstract class BaseUserTest : BaseTest
{
	protected IPasswordHasher PasswordHasher { get; }
	protected string Password { get; }

	protected UserBuilderFactory UserBuilderFactory { get; }
	protected UserBuilder UserBuilder { get; }
	protected User User { get; }
	protected ICollection<User> Users { get; }

	protected ForgotPasswordTokenBuilderFactory ForgotPasswordTokenBuilderFactory { get; }
	protected ForgotPasswordTokenBuilder ForgotPasswordTokenBuilder { get; }
	protected ForgotPasswordToken ForgotPasswordToken { get; }
	protected ICollection<ForgotPasswordToken> ForgotPasswordTokens { get; }

	protected EmailConfirmationTokenBuilderFactory EmailConfirmationTokenBuilderFactory { get; }
	protected EmailConfirmationTokenBuilder EmailConfirmationTokenBuilder { get; }
	protected EmailConfirmationToken EmailConfirmationToken { get; }
	protected ICollection<EmailConfirmationToken> EmailConfirmationTokens { get; }

	protected CancellationToken CancellationToken { get; }

	protected BaseUserTest(IPasswordHasher passwordHasher)
	{
		PasswordHasher = passwordHasher;
		Password = UserDataFaker.GetPassword();

		UserBuilderFactory = new();
		UserBuilder = UserBuilderFactory.Create(PasswordHasher.Hash(Password));
		User = UserBuilder.Build();
		Users = User.Generate();

		ForgotPasswordTokenBuilderFactory = new();
		ForgotPasswordTokenBuilder = ForgotPasswordTokenBuilderFactory.Create(User);
		ForgotPasswordToken = ForgotPasswordTokenBuilder.Build();
		ForgotPasswordTokens = ForgotPasswordToken.Generate(Users);

		EmailConfirmationTokenBuilderFactory = new();
		EmailConfirmationTokenBuilder = EmailConfirmationTokenBuilderFactory.Create(User);
		EmailConfirmationToken = EmailConfirmationTokenBuilder.Build();
		EmailConfirmationTokens = EmailConfirmationToken.Generate(Users);

		CancellationToken = MockFactory.CreateCancellationToken();
	}
}
