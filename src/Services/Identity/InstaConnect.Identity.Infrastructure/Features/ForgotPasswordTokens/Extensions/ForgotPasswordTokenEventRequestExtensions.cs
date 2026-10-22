using InstaConnect.Common.Infrastructure.Features.Events.Utilities;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

public static class ForgotPasswordTokenEventRequestExtensions
{
	extension(ForgotPasswordTokenEventRequest forgotPasswordToken)
	{
		public string GetKey()
		{
			return CommonEventKeySelectorMessages.GetKey(forgotPasswordToken.Value);
		}
	}
}
