using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Identity.Presentation.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Extensions;

internal static class UserHttpClientExtensions
{
	extension(HttpClient httpClient)
	{
		internal async Task<HttpResponseMessage> GetAllResponseMessageAsync(
			GetAllUsersApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetByIdResponseMessageAsync(
			GetUserByIdApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetCurrentByIdUnauthorizedResponseMessageAsync(
			GetCurrentUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetCurrentByIdResponseMessageAsync(
			GetCurrentUserByIdApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAdminAuthorization(request.CurrentId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetDetailsByIdUnauthorizedResponseMessageAsync(
			GetUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetDetailsByIdForbiddenResponseMessageAsync(
			GetUserDetailsByIdApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetDetailsByIdResponseMessageAsync(
			GetUserDetailsByIdApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAdminAuthorization(request.CurrentId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetCurrentDetailsByIdUnauthorizedResponseMessageAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetCurrentDetailsByIdResponseMessageAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> AddResponseMessageAsync(
			AddUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsync(route, request.Form.GetContent(), cancellationToken);
		}

		internal async Task<HttpResponseMessage> UpdateCurrentUnauthorizedResponseMessageAsync(
			UpdateCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.PutAsJsonAsync(route, request.Form.GetContent(), cancellationToken);
		}

		internal async Task<HttpResponseMessage> UpdateCurrentResponseMessageAsync(
			UpdateCurrentUserApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.Id, baseAccessTokenGenerator)
				.PutAsync(route, request.Form.GetContent(), cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteUnauthorizedResponseMessageAsync(
			DeleteUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.DeleteAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteForbiddenResponseMessageAsync(
			DeleteUserApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.Id, baseAccessTokenGenerator)
				.DeleteAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteResponseMessageAsync(
			DeleteUserApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAdminAuthorization(request.Id, baseAccessTokenGenerator)
				.DeleteAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteCurrentUnauthorizedResponseMessageAsync(
			DeleteCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.DeleteAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteCurrentResponseMessageAsync(
			DeleteCurrentUserApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentId, baseAccessTokenGenerator)
				.DeleteAsync(route, cancellationToken);
		}
	}
}
