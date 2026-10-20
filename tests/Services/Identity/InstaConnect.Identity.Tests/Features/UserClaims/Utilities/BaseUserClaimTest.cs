using InstaConnect.Identity.Tests.Features.UserClaims.Builders;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public abstract class BaseUserClaimTest : BaseTest
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

	protected BaseUserClaimTest(IPasswordHasher passwordHasher)
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
	}
}
