using System.Net.Http.Json;

using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Common.Presentation.Tests.Features.Extensions;
using InstaConnect.Posts.Presentation.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Extensions;

internal static class PostHttpClientExtensions
{
	extension(HttpClient httpClient)
	{
		internal async Task<HttpResponseMessage> GetAllResponseMessageAsync(
			GetAllPostsApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = PostRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetAllForUserResponseMessageAsync(
			GetAllPostsForUserApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = PostRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetByIdResponseMessageAsync(
			GetPostByIdApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = PostRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> AddUnauthorizedResponseMessageAsync(
			AddPostApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = PostRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsync(route, request.Form.GetContent(), cancellationToken);
		}

		internal async Task<HttpResponseMessage> AddResponseMessageAsync(
			AddPostApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = PostRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.UserId, baseAccessTokenGenerator)
				.PostAsync(route, request.Form.GetContent(), cancellationToken);
		}

		internal async Task<HttpResponseMessage> UpdateUnauthorizedResponseMessageAsync(
			UpdatePostApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = PostRouteFactory.GetRoute(request);

			return await httpClient
				.PutAsJsonAsync(route, request.Body, cancellationToken);
		}

		internal async Task<HttpResponseMessage> UpdateResponseMessageAsync(
			UpdatePostApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = PostRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.UserId, baseAccessTokenGenerator)
				.PutAsJsonAsync(route, request.Body, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteUnauthorizedResponseMessageAsync(
			DeletePostApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = PostRouteFactory.GetRoute(request);

			return await httpClient
				.DeleteAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteResponseMessageAsync(
			DeletePostApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = PostRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.UserId, baseAccessTokenGenerator)
				.DeleteAsync(route, cancellationToken);
		}
	}
}
