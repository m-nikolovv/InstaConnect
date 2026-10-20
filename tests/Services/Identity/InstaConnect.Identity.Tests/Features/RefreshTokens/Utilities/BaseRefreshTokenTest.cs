using InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Tests.Features.UserClaims.Builders;

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

	protected BaseRefreshTokenTest(IPasswordHasher passwordHasher)
	{
		PasswordHasher = passwordHasher;
		Password = UserDataFaker.GetPassword();
		NewPassword = UserDataFaker.GetPassword();

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

		ExpiredDate = RefreshTokenDataFaker.GetExpired(RefreshToken.ExpiresAtUtc);
		UnexpiredDate = RefreshTokenDataFaker.GetUnexpired(RefreshToken.ExpiresAtUtc);
	}
}
