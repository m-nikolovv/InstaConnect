using InstaConnect.Posts.Presentation.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Extensions;

internal static class PostCommentHttpClientExtensions
{
	extension(HttpClient httpClient)
	{
		internal async Task<HttpResponseMessage> GetAllResponseMessageAsync(
			GetAllPostCommentsApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = PostCommentRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetAllForUserResponseMessageAsync(
			GetAllPostCommentsForUserApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = PostCommentRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> GetByIdResponseMessageAsync(
			GetPostCommentByIdApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = PostCommentRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId, baseAccessTokenGenerator)
				.GetAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> AddUnauthorizedResponseMessageAsync(
			AddPostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = PostCommentRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsync(route, request.Form.GetContent(), cancellationToken);
		}

		internal async Task<HttpResponseMessage> AddResponseMessageAsync(
			AddPostCommentApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = PostCommentRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.UserId, baseAccessTokenGenerator)
				.PostAsync(route, request.Form.GetContent(), cancellationToken);
		}

		internal async Task<HttpResponseMessage> UpdateUnauthorizedResponseMessageAsync(
			UpdatePostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = PostCommentRouteFactory.GetRoute(request);

			return await httpClient
				.PutAsJsonAsync(route, request.Body, cancellationToken);
		}

		internal async Task<HttpResponseMessage> UpdateResponseMessageAsync(
			UpdatePostCommentApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = PostCommentRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.UserId, baseAccessTokenGenerator)
				.PutAsJsonAsync(route, request.Body, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteUnauthorizedResponseMessageAsync(
			DeletePostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = PostCommentRouteFactory.GetRoute(request);

			return await httpClient
				.DeleteAsync(route, cancellationToken);
		}

		internal async Task<HttpResponseMessage> DeleteResponseMessageAsync(
			DeletePostCommentApiRequest request,
			IBaseAccessTokenGenerator baseAccessTokenGenerator,
			CancellationToken cancellationToken)
		{
			var route = PostCommentRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.UserId, baseAccessTokenGenerator)
				.DeleteAsync(route, cancellationToken);
		}
	}
}
