using InstaConnect.Posts.Application.Features.Posts.Models;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<Post?> GetByIdAsync(
		PostIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new PostId(id.Id),
				cancellationToken);
		}

		public async Task<Post?> GetByIdAsync(
			AddPostCommandResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<Post?> GetByIdAsync(
			UpdatePostCommandResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}
	}
}
