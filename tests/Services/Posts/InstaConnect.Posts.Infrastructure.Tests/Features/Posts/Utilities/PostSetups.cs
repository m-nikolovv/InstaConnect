using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Utilities;

public static class PostSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<PostResponse?> GetPostCacheByIdAsync(
			PostId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}
	}

}
