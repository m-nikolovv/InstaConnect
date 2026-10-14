using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenTest : BaseTest
{
	protected IPasswordHasher PasswordHasher { get; }
	protected string Password { get; }
	protected string NewPassword { get; }
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

	protected RefreshTokenBuilderFactory RefreshTokenBuilderFactory { get; }
	protected RefreshTokenBuilder RefreshTokenBuilder { get; }
	protected RefreshToken RefreshToken { get; }
	protected ICollection<RefreshToken> RefreshTokens { get; }

	protected CancellationToken CancellationToken { get; }

	protected BaseRefreshTokenTest(IPasswordHasher passwordHasher)
	{
		PasswordHasher = passwordHasher;
		Password = UserDataFaker.GetPassword();
		NewPassword = UserDataFaker.GetPassword();

		UserBuilderFactory = new();
		UserBuilder = UserBuilderFactory.Create(PasswordHasher.Hash(Password));
		User = UserBuilder.Build();
		Users = User.Generate();

		UserClaimBuilderFactory = new();
		UserClaimBuilder = UserClaimBuilderFactory.Create(User);
		UserClaim = UserClaimBuilder.Build();
		UserClaims = UserClaim.Generate(Users);

		RefreshTokenBuilderFactory = new();
		RefreshTokenBuilder = RefreshTokenBuilderFactory.Create(User);
		RefreshToken = RefreshTokenBuilder.Build();
		RefreshTokens = RefreshToken.Generate(Users);

		ExpiredDate = RefreshTokenDataFaker.GetExpired(RefreshToken.ExpiresAtUtc);
		UnexpiredDate = RefreshTokenDataFaker.GetUnexpired(RefreshToken.ExpiresAtUtc);

		CancellationToken = MockFactory.CreateCancellationToken();
	}
}
