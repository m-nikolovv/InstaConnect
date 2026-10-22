using InstaConnect.Common.Infrastructure.Features.Events.Utilities;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

public static class UserEventRequestExtensions
{
	extension(UserEventRequest user)
	{
		public string GetKey()
		{
			return CommonEventKeySelectorMessages.GetKey(user.Id);
		}
	}
}
