using InstaConnect.Follows.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Tests.Features.Users.Assertions;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Assertions;

public static class FollowExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowFollowingNotFoundExceptionAsync(
		GetAllFollowsForFollowingQueryRequest request,
		CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.FollowingId,
				cancellationToken);
		}

		public async Task ShouldThrowFollowingNotFoundExceptionAsync(
			AddFollowCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.FollowingId,
				cancellationToken);
		}

		public async Task ShouldThrowFollowerNotFoundExceptionAsync(
			AddFollowCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.FollowerId,
				cancellationToken);
		}

		public async Task ShouldThrowFollowerNotFoundExceptionAsync(
			DeleteFollowCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.FollowerId,
				cancellationToken);
		}

		public async Task ShouldThrowFollowerNotFoundExceptionAsync(
			GetFollowByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.FollowerId,
				cancellationToken);
		}

		public async Task ShouldThrowFollowerNotFoundExceptionAsync(
			GetAllFollowsQueryRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.FollowerId,
				cancellationToken);
		}

		public async Task ShouldThrowFollowNotFoundExceptionAsync(
			DeleteFollowCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowFollowNotFoundExceptionAsync(
				request,
				r => r.FollowerId,
				r => r.FollowingId,
				cancellationToken);
		}

		public async Task ShouldThrowFollowNotFoundExceptionAsync(
			GetFollowByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowFollowNotFoundExceptionAsync(
				request,
				r => r.FollowerId,
				r => r.FollowingId,
				cancellationToken);
		}

		public async Task ShouldThrowFollowAlreadyExistsExceptionAsync(
			AddFollowCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowFollowAlreadyExistsExceptionAsync(
				request,
				r => r.FollowerId,
				r => r.FollowingId,
				cancellationToken);
		}
	}
}
