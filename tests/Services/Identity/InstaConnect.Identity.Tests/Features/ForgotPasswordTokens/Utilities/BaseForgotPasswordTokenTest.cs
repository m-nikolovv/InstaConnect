using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;
using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenTest : BaseTest
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

	protected BaseForgotPasswordTokenTest(IPasswordHasher passwordHasher)
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

		ExpiredDate = ForgotPasswordTokenDataFaker.GetExpired(ForgotPasswordToken.ExpiresAtUtc);
		UnexpiredDate = ForgotPasswordTokenDataFaker.GetUnexpired(ForgotPasswordToken.ExpiresAtUtc);
	}
}
