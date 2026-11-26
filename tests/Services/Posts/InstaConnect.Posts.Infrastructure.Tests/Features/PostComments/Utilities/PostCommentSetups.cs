using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;

public static class PostCommentSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			PostCommentId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}
	}
}
