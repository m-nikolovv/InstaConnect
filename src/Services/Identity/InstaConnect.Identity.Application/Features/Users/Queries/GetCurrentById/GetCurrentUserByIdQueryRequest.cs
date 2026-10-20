using InstaConnect.Common.Application.Features.Caches.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentById;

public record GetCurrentUserByIdQueryRequest(string CurrentId) : IQueryRequest<GetCurrentUserByIdQueryResponse>, ICachable, ICurrentUserableQueryRequest
{
	public string Key => UserCacheKeys.GetCurrent(CurrentId);

	public int ExpirationSeconds => UserCacheExpirations.GetCurrent;
}
