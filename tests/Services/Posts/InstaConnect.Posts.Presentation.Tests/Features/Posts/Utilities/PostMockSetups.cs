using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Application.Tests.Features.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllPostsApiRequest request,
		ICollection<Post> posts,
		CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetAllPostsQueryRequest(), posts.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			GetAllPostsForUserApiRequest request,
			User user,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetAllPostsForUserQueryRequest(), posts.ToResponse(request, user), cancellationToken);
		}

		public void SetupSendAsync(
			GetPostByIdApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetPostByIdQueryRequest(), post.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			AddPostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsAddPostCommandRequest(), post.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			UpdatePostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsUpdatePostCommandRequest(), post.ToResponse(request), cancellationToken);
		}
	}
}
