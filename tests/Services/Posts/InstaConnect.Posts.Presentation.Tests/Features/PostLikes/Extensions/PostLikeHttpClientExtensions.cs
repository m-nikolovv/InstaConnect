using InstaConnect.Posts.Presentation.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Extensions;

internal static class PostLikeHttpClientExtensions
{
	extension(HttpClient httpClient)
	{
		internal async Task<HttpResponseMessage> GetAllResponseMessageAsync(
			GetAllPostLikesApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = PostLikeRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetAllForUserResponseMessageAsync(
			GetAllPostLikesForUserApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = PostLikeRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetByIdResponseMessageAsync(
			GetPostLikeByIdApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = PostLikeRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> AddUnauthorizedResponseMessageAsync(
			AddPostLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = PostLikeRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsync(route, null, cancellationToken);
		}

		internal async Task<HttpResponseMessage> AddResponseMessageAsync(
			AddPostLikeApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = PostLikeRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.UserId, baseAccessTokenGenerator)
				.PostAsync(route, null, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteUnauthorizedResponseMessageAsync(
			DeletePostLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = PostLikeRouteFactory.GetRoute(request);

			return await httpClient
				.DeleteAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteResponseMessageAsync(
			DeletePostLikeApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = PostLikeRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.UserId, baseAccessTokenGenerator)
				.DeleteAsync(route, cancellationToken);
		}
	}
}
