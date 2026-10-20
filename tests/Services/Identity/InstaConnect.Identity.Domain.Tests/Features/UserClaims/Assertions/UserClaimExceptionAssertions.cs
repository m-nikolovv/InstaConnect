using InstaConnect.Identity.Tests.Features.UserClaims.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Assertions;

public static class UserClaimExceptionAssertions
{
	extension(IUserClaimCommandService service)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddUserClaimCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			DeleteUserClaimCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserClaimAlreadyExistsExceptionAsync(
			AddUserClaimCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserClaimAlreadyExistsExceptionAsync(
				request,
				r => r.Id.Id,
				r => r.Claim,
				cancellationToken);
		}

		public async Task ShouldThrowUserClaimNotFoundExceptionAsync(
			DeleteUserClaimCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowUserClaimNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}
	}

	extension(IUserClaimQueryService service)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetAllUserClaimsQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Filter.Id,
				cancellationToken);
		}
	}
}
