using InstaConnect.Identity.Presentation.Features.Users.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Assertions;

public static class UserExceptionAssertions
{
	extension(UserController controller)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetDetailsByIdAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetCurrentUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetCurrentByIdAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.CurrentId,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetCurrentDetailsByIdAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.CurrentId,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			DeleteUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			DeleteCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteCurrentAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.CurrentId,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			UpdateCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.UpdateCurrentAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyTakenExceptionAsync(
			AddUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyTakenExceptionAsync(
				request,
				r => r.Form.Email,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyTakenExceptionAsync(
			UpdateCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.UpdateCurrentAsync(request, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyTakenExceptionAsync(
				request,
				r => r.Form.Email,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyTakenExceptionAsync(
			AddUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNameAlreadyTakenExceptionAsync(
				request,
				r => r.Form.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyTakenExceptionAsync(
			UpdateCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.UpdateCurrentAsync(request, cancellationToken);

			await func.ShouldThrowUserNameAlreadyTakenExceptionAsync(
				request,
				r => r.Form.Name,
				cancellationToken);
		}
	}
}
