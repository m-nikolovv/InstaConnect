using InstaConnect.Identity.Presentation.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Extensions;

internal static class UserClaimHttpClientExtensions
{
	extension(HttpClient httpClient)
	{
		internal async Task<HttpResponseMessage> GetAllUnauthorizedResponseMessageAsync(
			GetAllUserClaimsApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserClaimRouteFactory.GetRoute(request);

			return await httpClient
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetAllForbiddenResponseMessageAsync(
			GetAllUserClaimsApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = UserClaimRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetAllResponseMessageAsync(
			GetAllUserClaimsApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = UserClaimRouteFactory.GetRoute(request);

			return await httpClient
				.WithAdminAuthorization(request.CurrentId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> AddUnauthorizedResponseMessageAsync(
			AddUserClaimApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserClaimRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsJsonAsync(route, request.Body, cancellationToken);
		}

		internal async Task<HttpResponseMessage> AddForbiddenResponseMessageAsync(
			AddUserClaimApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = UserClaimRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.Id, baseAccessTokenGenerator)
				.PostAsJsonAsync(route, request.Body, cancellationToken);
		}

		internal async Task<HttpResponseMessage> AddResponseMessageAsync(
			AddUserClaimApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = UserClaimRouteFactory.GetRoute(request);

			return await httpClient
				.WithAdminAuthorization(request.Id, baseAccessTokenGenerator)
				.PostAsJsonAsync(route, request.Body, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteUnauthorizedResponseMessageAsync(
			DeleteUserClaimApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserClaimRouteFactory.GetRoute(request);

			return await httpClient
				.DeleteAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteForbiddenResponseMessageAsync(
			DeleteUserClaimApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = UserClaimRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.Id, baseAccessTokenGenerator)
				.DeleteAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteResponseMessageAsync(
			DeleteUserClaimApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = UserClaimRouteFactory.GetRoute(request);

			return await httpClient
				.WithAdminAuthorization(request.Id, baseAccessTokenGenerator)
				.DeleteAsync(route, cancellationToken);
		}
	}
}
