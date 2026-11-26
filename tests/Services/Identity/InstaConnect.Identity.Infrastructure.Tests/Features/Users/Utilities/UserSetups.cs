using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.Users.Models.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<UserResponse?> GetUserCacheByIdAsync(
			User user,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(user.Id, user.Id, cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			UserId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}

		public async Task SetupUpdateUserAsync(
			User user,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateUserAsync(user, emailConfirmationTokens, user.Id, cancellationToken);
		}

		public async Task SetupDeleteUserAsync(
			User user,
			ICollection<UserClaim> userClaims,
			ICollection<RefreshToken> refreshTokens,
			ICollection<ForgotPasswordToken> forgotPasswordTokens,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteUserAsync(user, userClaims, refreshTokens, forgotPasswordTokens, emailConfirmationTokens, user.Id, cancellationToken);
		}
	}

}
