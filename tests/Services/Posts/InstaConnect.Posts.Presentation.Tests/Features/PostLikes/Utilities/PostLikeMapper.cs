using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikeMapper
{
	extension(PostLike postLike)
	{
		internal PostLikeIdCommandResponse ToIdCommandResponse(
)
		{
			return new(postLike.Id.Id.Id, postLike.Id.UserId.Id);
		}

		internal PostLikeQueryResponse ToFullQueryResponse<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postLike.Id.Id.Id,
					   postLike.Id.UserId.Id,
					   postLike.User?.ToFullQueryResponse(),
					   postLike.Post?.ToFullQueryResponse(request),
					   postLike.CreatedAtUtc);
		}

		internal PostLikeQueryResponse ToQueryResponseWithoutUser<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postLike.Id.Id.Id,
					   postLike.Id.UserId.Id,
					   null,
					   postLike.Post?.ToFullQueryResponse(request),
					   postLike.CreatedAtUtc);
		}

		internal PostLikeQueryResponse ToQueryResponseWithoutPost()
		{
			return new(postLike.Id.Id.Id,
					   postLike.Id.UserId.Id,
					   postLike.User?.ToFullQueryResponse(),
					   null,
					   postLike.CreatedAtUtc);
		}

		public AddPostLikeCommandResponse ToResponse(
			AddPostLikeApiRequest request)
		{
			return new(postLike.ToIdCommandResponse());
		}

		public GetPostLikeByIdQueryResponse ToResponse(
			GetPostLikeByIdApiRequest request)
		{
			return new(postLike.ToFullQueryResponse(request));
		}
	}

	extension(ICollection<PostLike> postLikes)
	{
		internal PostLikeCollectionQueryResponse ToQueryResponseWithoutUser<TRequest>(
		TRequest request,
		Post post,
		Func<TRequest, PostLike, bool> filter,
		Func<TRequest, PostLike, PostLikeQueryResponse> transform)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = postLikes.Count(postLike => filter(request, postLike));

			return new(post.ToFullQueryResponse(request),
					   null,
					   postLikes.Filter(request, postLike => filter(request, postLike), postLike => transform(request, postLike)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal PostLikeCollectionQueryResponse ToQueryResponseWithoutPost<TRequest>(
			TRequest request,
			User user,
			Func<TRequest, PostLike, bool> filter,
			Func<TRequest, PostLike, PostLikeQueryResponse> transform)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = postLikes.Count(postLike => filter(request, postLike));

			return new(null,
					   user.ToFullQueryResponse(),
					   postLikes.Filter(request, postLike => filter(request, postLike), postLike => transform(request, postLike)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public GetAllPostLikesQueryResponse ToResponse(
			GetAllPostLikesApiRequest request,
			Post post)
		{
			return new(postLikes.ToQueryResponseWithoutUser(
													   request,
													   post,
													   (request, postLike) => postLike.MatchesFilter(request),
													   (request, postLike) => postLike.ToQueryResponseWithoutPost()));
		}

		public GetAllPostLikesForUserQueryResponse ToResponse(
			GetAllPostLikesForUserApiRequest request,
			User user)
		{
			return new(postLikes.ToQueryResponseWithoutPost(
													   request,
													   user,
													   (request, postLike) => postLike.MatchesFilter(request),
													   (request, postLike) => postLike.ToQueryResponseWithoutUser(request)));
		}
	}
}
