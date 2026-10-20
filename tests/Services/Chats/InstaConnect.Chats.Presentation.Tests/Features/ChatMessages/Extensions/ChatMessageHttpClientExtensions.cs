using System.Net.Http.Json;

using InstaConnect.Chats.Presentation.Features.ChatMessages.Utilities;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Extensions;

internal static class ChatMessageHttpClientExtensions
{
	extension(HttpClient httpClient)
	{
		internal async Task<HttpResponseMessage> GetAllUnauthorizedResponseMessageAsync(
			GetAllChatMessagesApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetAllResponseMessageAsync(
			GetAllChatMessagesApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetByIdUnauthorizedResponseMessageAsync(
			GetChatMessageByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetByIdResponseMessageAsync(
			GetChatMessageByIdApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> AddUnauthorizedResponseMessageAsync(
			AddChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsync(route, request.Form.GetContent(), cancellationToken);
		}

		internal async Task<HttpResponseMessage> AddResponseMessageAsync(
			AddChatMessageApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.ParticipantOneId, baseAccessTokenGenerator)
				.PostAsync(route, request.Form.GetContent(), cancellationToken);
		}

		internal async Task<HttpResponseMessage> UpdateUnauthorizedResponseMessageAsync(
			UpdateChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.PutAsJsonAsync(route, request.Body, cancellationToken);
		}

		internal async Task<HttpResponseMessage> UpdateResponseMessageAsync(
			UpdateChatMessageApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.ParticipantOneId, baseAccessTokenGenerator)
				.PutAsJsonAsync(route, request.Body, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteUnauthorizedResponseMessageAsync(
			DeleteChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.DeleteAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteResponseMessageAsync(
			DeleteChatMessageApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.ParticipantOneId, baseAccessTokenGenerator)
				.DeleteAsync(route, cancellationToken);
		}
	}
}
