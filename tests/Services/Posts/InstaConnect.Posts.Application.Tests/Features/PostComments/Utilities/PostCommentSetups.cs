using InstaConnect.Posts.Application.Features.PostComments.Models;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<PostComment?> GetByIdAsync(
		PostCommentIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new PostCommentId(
							   new(id.Id),
							   id.CommentId),
				cancellationToken);
		}

		public async Task<PostComment?> GetByIdAsync(
			AddPostCommentCommandResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<PostComment?> GetByIdAsync(
			UpdatePostCommentCommandResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}
	}
}
