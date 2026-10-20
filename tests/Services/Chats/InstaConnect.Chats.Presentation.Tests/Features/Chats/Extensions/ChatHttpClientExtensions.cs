using System.Net.Http.Json;

using InstaConnect.Chats.Presentation.Features.Chats.Utilities;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Extensions;

internal static class ChatHttpClientExtensions
{
	extension(HttpClient httpClient)
	{
		internal async Task<HttpResponseMessage> GetAllUnauthorizedResponseMessageAsync(
			GetAllChatsApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatRouteFactory.GetRoute(request);

			return await httpClient
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetAllResponseMessageAsync(
			GetAllChatsApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = ChatRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetByIdUnauthorizedResponseMessageAsync(
			GetChatByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatRouteFactory.GetRoute(request);

			return await httpClient
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetByIdResponseMessageAsync(
			GetChatByIdApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = ChatRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> AddUnauthorizedResponseMessageAsync(
			AddChatApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsJsonAsync(route, request.Body, cancellationToken);
		}

		internal async Task<HttpResponseMessage> AddResponseMessageAsync(
			AddChatApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = ChatRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.ParticipantOneId, baseAccessTokenGenerator)
				.PostAsJsonAsync(route, request.Body, cancellationToken);
		}
	}
}
