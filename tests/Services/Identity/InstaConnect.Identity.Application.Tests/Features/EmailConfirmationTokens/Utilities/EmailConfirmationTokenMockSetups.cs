using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenMockSetups
{
	extension(IEmailConfirmationTokenCommandService service)
	{
		public void SetupAddAsync(
			AddEmailConfirmationTokenCommandRequest request,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			service.SetupAddAsync(request.IsAddEmailConfirmationTokenCommand(), emailConfirmationToken.ToResponse(request), cancellationToken);
		}
	}
}
