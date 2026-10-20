using InstaConnect.Identity.Presentation.Features.UserClaims.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Assertions;

public static class UserClaimExceptionAssertions
{
	extension(UserClaimController controller)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddUserClaimApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			DeleteUserClaimApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetAllUserClaimsApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserClaimAlreadyExistsExceptionAsync(
			AddUserClaimApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserClaimAlreadyExistsExceptionAsync(
				request,
				r => r.Id,
				r => r.Body.Claim,
				cancellationToken);
		}

		public async Task ShouldThrowUserClaimNotFoundExceptionAsync(
			DeleteUserClaimApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowUserClaimNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.Claim,
				cancellationToken);
		}
	}
}
