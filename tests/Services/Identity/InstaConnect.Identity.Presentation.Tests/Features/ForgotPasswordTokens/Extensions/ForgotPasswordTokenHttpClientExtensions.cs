using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Extensions;

internal static class ForgotPasswordTokenHttpClientExtensions
{
	extension(HttpClient httpClient)
	{
		internal async Task<HttpResponseMessage> AddResponseMessageAsync(
			AddForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ForgotPasswordTokenRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsync(route, null, cancellationToken);
		}

		internal async Task<HttpResponseMessage> VerifyResponseMessageAsync(
			VerifyForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ForgotPasswordTokenRouteFactory.GetRoute(request);

			return await httpClient
				.PutAsJsonAsync(route, request.Body, cancellationToken);
		}
	}
}
