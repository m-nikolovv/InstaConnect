using InstaConnect.Follows.Presentation.Tests.Features.Follows.Assertions;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Assertions;

public static class FollowMockAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldHaveReceivedOneSendAsync(
		GetAllFollowsApiRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsGetAllFollowsQueryRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			GetAllFollowsForFollowingApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsGetAllFollowsForFollowingQueryRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			GetFollowByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsGetFollowByIdQueryRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			AddFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsAddFollowCommandRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			DeleteFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsDeleteFollowCommandRequest(), cancellationToken);
		}
	}
}
