using InstaConnect.Common.Application.Features.Caches.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Application.Features.Users.Commands.UpdateCurrent;

public record UpdateCurrentUserCommandRequest(
	string Id,
	string Email,
	string FirstName,
	string LastName,
	string Name,
	IFormFile? ProfileImage) : ICommandRequest<UpdateCurrentUserCommandResponse>, ICacheInvalidating
{
	public ICollection<string> InvalidatedKeys => [UserCacheKeys.GetCurrent(Id), UserCacheKeys.GetCurrentDetailed(Id)];
}
