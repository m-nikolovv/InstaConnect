using InstaConnect.Identity.Presentation.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Extensions;

internal static class RefreshTokenHttpClientExtensions
{
	extension(HttpClient httpClient)
	{
		internal async Task<HttpResponseMessage> IssueResponseMessageAsync(
			IssueRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = RefreshTokenRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsJsonAsync(route, request.Body, cancellationToken);
		}

		internal async Task<HttpResponseMessage> RotateWithoutCookiesResponseMessageAsync(
			RotateRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = RefreshTokenRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsync(route, null, cancellationToken);
		}

		internal async Task<HttpResponseMessage> RotateResponseMessageAsync(
			RotateRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = RefreshTokenRouteFactory.GetRoute(request);

			return await httpClient
				.WithRefreshTokenCookies(request.Id, request.Value)
				.PostAsync(route, null, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteCurrentWithoutCookiesResponseMessageAsync(
			DeleteCurrentRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = RefreshTokenRouteFactory.GetRoute(request);

			return await httpClient
				.DeleteAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteCurrentResponseMessageAsync(
			DeleteCurrentRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = RefreshTokenRouteFactory.GetRoute(request);

			return await httpClient
				.WithRefreshTokenCookies(request.Id, request.Value)
				.DeleteAsync(route, cancellationToken);
		}

		internal HttpClient WithRefreshTokenCookies(
			string id,
			string value)
		{
			return httpClient
				.WithCookies(new(RefreshTokenCookieKeys.Id, id),
							 new(RefreshTokenCookieKeys.Value, value));
		}
	}

	extension(HttpResponseMessage httpResponseMessage)
	{
		internal RefreshTokenCookieApiResponse? GetRefreshTokenCookieApiResponse()
		{
			var id = httpResponseMessage.GetCookie(RefreshTokenCookieKeys.Id);
			var value = httpResponseMessage.GetCookie(RefreshTokenCookieKeys.Value);

			if (id.IsEmpty() && value.IsEmpty())
			{
				return null;
			}

			return new(id, value);
		}
	}
}
