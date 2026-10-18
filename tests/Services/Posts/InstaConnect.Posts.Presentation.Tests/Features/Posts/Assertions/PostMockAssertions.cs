using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Application.Tests.Features.Assertions;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostMockAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldHaveReceivedOneSendAsync(
		GetAllPostsApiRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsGetAllPostsQueryRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			GetAllPostsForUserApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsGetAllPostsForUserQueryRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			GetPostByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsGetPostByIdQueryRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			AddPostApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsAddPostCommandRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			UpdatePostApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsUpdatePostCommandRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			DeletePostApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsDeletePostCommandRequest(), cancellationToken);
		}
	}
}
