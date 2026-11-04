using InstaConnect.Common.Application.Features.Caches.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.Users.Commands.Delete;

public record DeleteUserCommandRequest(string Id) : ICommandRequest, ICacheInvalidating
{
	public ICollection<string> InvalidatedKeys => [UserCacheKeys.GetCurrent(Id), UserCacheKeys.GetCurrentDetailed(Id)];
}
