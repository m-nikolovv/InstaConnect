using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Tests.Features.UserClaims.Builders;

namespace InstaConnect.Identity.Tests.Features.Common.Utilities;

public abstract class BaseIdentityCommandTest : BaseIdentityTest
{
	protected ICollection<UserClaim> UserUserClaims { get; }
	protected UserClaimIdRangeBuilderFactory UserUserClaimIdRangeBuilderFactory { get; }
	protected UserClaimIdRangeBuilder UserUserClaimIdRangeBuilder { get; }
	protected ICollection<UserClaimId> UserUserClaimIds { get; }

	protected ICollection<RefreshToken> UserRefreshTokens { get; }
	protected RefreshTokenIdRangeBuilderFactory UserRefreshTokenIdRangeBuilderFactory { get; }
	protected RefreshTokenIdRangeBuilder UserRefreshTokenIdRangeBuilder { get; }
	protected ICollection<RefreshTokenId> UserRefreshTokenIds { get; }

	protected ICollection<ForgotPasswordToken> UserForgotPasswordTokens { get; }
	protected ForgotPasswordTokenIdRangeBuilderFactory UserForgotPasswordTokenIdRangeBuilderFactory { get; }
	protected ForgotPasswordTokenIdRangeBuilder UserForgotPasswordTokenIdRangeBuilder { get; }
	protected ICollection<ForgotPasswordTokenId> UserForgotPasswordTokenIds { get; }

	protected ICollection<EmailConfirmationToken> UserEmailConfirmationTokens { get; }
	protected EmailConfirmationTokenIdRangeBuilderFactory UserEmailConfirmationTokenIdRangeBuilderFactory { get; }
	protected EmailConfirmationTokenIdRangeBuilder UserEmailConfirmationTokenIdRangeBuilder { get; }
	protected ICollection<EmailConfirmationTokenId> UserEmailConfirmationTokenIds { get; }
	protected BaseIdentityCommandTest(IPasswordHasher passwordHasher, bool isEmailConfirmed = true) : base(passwordHasher, isEmailConfirmed)
	{
		UserUserClaims = User.UserClaims;
		UserUserClaimIdRangeBuilderFactory = new();
		UserUserClaimIdRangeBuilder = UserUserClaimIdRangeBuilderFactory.Create([.. UserUserClaims.Select(u => u.Id)]);
		UserUserClaimIds = UserUserClaimIdRangeBuilder.Build();

		UserRefreshTokens = User.RefreshTokens;
		UserRefreshTokenIdRangeBuilderFactory = new();
		UserRefreshTokenIdRangeBuilder = UserRefreshTokenIdRangeBuilderFactory.Create([.. UserRefreshTokens.Select(r => r.Id)]);
		UserRefreshTokenIds = UserRefreshTokenIdRangeBuilder.Build();

		UserForgotPasswordTokens = User.ForgotPasswordTokens;
		UserForgotPasswordTokenIdRangeBuilderFactory = new();
		UserForgotPasswordTokenIdRangeBuilder = UserForgotPasswordTokenIdRangeBuilderFactory.Create([.. UserForgotPasswordTokens.Select(f => f.Id)]);
		UserForgotPasswordTokenIds = UserForgotPasswordTokenIdRangeBuilder.Build();

		UserEmailConfirmationTokens = User.EmailConfirmationTokens;
		UserEmailConfirmationTokenIdRangeBuilderFactory = new();
		UserEmailConfirmationTokenIdRangeBuilder = UserEmailConfirmationTokenIdRangeBuilderFactory.Create([.. UserEmailConfirmationTokens.Select(e => e.Id)]);
		UserEmailConfirmationTokenIds = UserEmailConfirmationTokenIdRangeBuilder.Build();
	}
}
