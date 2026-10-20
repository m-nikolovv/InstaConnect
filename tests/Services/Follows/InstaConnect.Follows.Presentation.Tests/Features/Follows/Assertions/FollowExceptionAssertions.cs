using InstaConnect.Follows.Presentation.Features.Follows.Controllers.v1;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Tests.Features.Users.Assertions;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Assertions;

public static class FollowExceptionAssertions
{
	extension(FollowController controller)
	{
		public async Task ShouldThrowFollowerNotFoundExceptionAsync(
			AddFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.FollowerId,
				cancellationToken);
		}

		public async Task ShouldThrowFollowerNotFoundExceptionAsync(
			GetAllFollowsApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.FollowerId,
				cancellationToken);
		}

		public async Task ShouldThrowFollowingNotFoundExceptionAsync(
			AddFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Body.FollowingId,
				cancellationToken);
		}

		public async Task ShouldThrowFollowNotFoundExceptionAsync(
			DeleteFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowFollowNotFoundExceptionAsync(
				request,
				r => r.FollowerId,
				r => r.FollowingId,
				cancellationToken);
		}

		public async Task ShouldThrowFollowNotFoundExceptionAsync(
			GetFollowByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowFollowNotFoundExceptionAsync(
				request,
				r => r.FollowerId,
				r => r.FollowingId,
				cancellationToken);
		}

		public async Task ShouldThrowFollowAlreadyExistsExceptionAsync(
			AddFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowFollowAlreadyExistsExceptionAsync(
				request,
				r => r.FollowerId,
				r => r.Body.FollowingId,
				cancellationToken);
		}
	}

	extension(FollowingFollowController controller)
	{
		public async Task ShouldThrowFollowingNotFoundExceptionAsync(
			GetAllFollowsForFollowingApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.FollowingId,
				cancellationToken);
		}
	}
}
