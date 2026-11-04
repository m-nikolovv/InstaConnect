using InstaConnect.Common.Application.Features.Caches.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.Users.Commands.DeleteCurrent;

public record DeleteCurrentUserCommandRequest(string CurrentId) : ICommandRequest, ICacheInvalidating
{
	public ICollection<string> InvalidatedKeys => [UserCacheKeys.GetCurrent(CurrentId), UserCacheKeys.GetCurrentDetailed(CurrentId)];
}
