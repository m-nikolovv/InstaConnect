namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Assertions;

public static class UserClaimExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetAllUserClaimsQueryRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddUserClaimCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			DeleteUserClaimCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserClaimAlreadyExistsExceptionAsync(
			AddUserClaimCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserClaimAlreadyExistsExceptionAsync(
				request,
				r => r.Id,
				r => r.Claim,
				cancellationToken);
		}

		public async Task ShouldThrowUserClaimNotFoundExceptionAsync(
			DeleteUserClaimCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserClaimNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.Claim,
				cancellationToken);
		}
	}
}
