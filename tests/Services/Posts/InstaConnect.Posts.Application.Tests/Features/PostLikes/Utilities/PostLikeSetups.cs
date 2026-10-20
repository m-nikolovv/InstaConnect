using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<PostLike?> GetByIdAsync(
		PostLikeIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new PostLikeId(
							   new(id.Id),
							   new(id.UserId)),
				cancellationToken);
		}

		public async Task<PostLike?> GetByIdAsync(
			AddPostLikeCommandResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}
	}
}
