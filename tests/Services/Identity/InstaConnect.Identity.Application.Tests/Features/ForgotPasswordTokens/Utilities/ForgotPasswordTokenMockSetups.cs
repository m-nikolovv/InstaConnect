using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenMockSetups
{
	extension(IForgotPasswordTokenCommandService service)
	{
		public void SetupAddAsync(
			AddForgotPasswordTokenCommandRequest request,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			service.SetupAddAsync(request.IsAddForgotPasswordTokenCommand(), forgotPasswordToken.ToResponse(request), cancellationToken);
		}

		public void SetupAddAsync(
			AddForgotPasswordTokenCommand command,
			ForgotPasswordTokenId id,
			CancellationToken cancellationToken)
		{
			service
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}
}
