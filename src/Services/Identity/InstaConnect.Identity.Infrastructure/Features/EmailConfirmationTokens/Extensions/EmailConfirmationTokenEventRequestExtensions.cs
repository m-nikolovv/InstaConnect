using InstaConnect.Common.Infrastructure.Features.Events.Utilities;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

public static class EmailConfirmationTokenEventRequestExtensions
{
	extension(EmailConfirmationTokenEventRequest emailConfirmationToken)
	{
		public string GetKey()
		{
			return CommonEventKeySelectorMessages.GetKey(emailConfirmationToken.Value);
		}
	}
}
