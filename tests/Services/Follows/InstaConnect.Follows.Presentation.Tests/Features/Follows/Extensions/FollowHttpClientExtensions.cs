using InstaConnect.Follows.Presentation.Features.Follows.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Extensions;

internal static class FollowHttpClientExtensions
{
	extension(HttpClient httpClient)
	{
		internal async Task<HttpResponseMessage> GetAllResponseMessageAsync(
			GetAllFollowsApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = FollowRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetAllForFollowingResponseMessageAsync(
			GetAllFollowsForFollowingApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = FollowRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetByIdResponseMessageAsync(
			GetFollowByIdApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = FollowRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> AddUnauthorizedResponseMessageAsync(
			AddFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = FollowRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsJsonAsync(route, request.Body, cancellationToken);
		}

		internal async Task<HttpResponseMessage> AddResponseMessageAsync(
			AddFollowApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = FollowRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.FollowerId, baseAccessTokenGenerator)
				.PostAsJsonAsync(route, request.Body, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteUnauthorizedResponseMessageAsync(
			DeleteFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = FollowRouteFactory.GetRoute(request);

			return await httpClient
				.DeleteAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteResponseMessageAsync(
			DeleteFollowApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = FollowRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.FollowerId, baseAccessTokenGenerator)
				.DeleteAsync(route, cancellationToken);
		}
	}
}
