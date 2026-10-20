using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;

namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

public static class PostLikeMapper
{
	extension(User user)
	{
		public UserResponse ToResponse(
			GetAllPostLikesForUserQuery query)
		{
			return user.ToFullResponse();
		}
	}

	extension(Post post)
	{
		public PostResponse ToResponse(
			GetAllPostLikesQuery query)
		{
			return post.ToFullResponse(query);
		}
	}

	extension(PostLike postLike)
	{
		internal PostLikeResponse ToFullResponse<TQuery>(
			TQuery request)
			where TQuery : ICurrentUserableQuery
		{
			return new(postLike.Id,
					   postLike.User?.ToFullResponse(),
					   postLike.Post?.ToFullResponse(request),
					   postLike.CreatedAtUtc);
		}

		internal PostLikeResponse ToResponseWithoutUser<TQuery>(
			TQuery request)
			where TQuery : ICurrentUserableQuery
		{
			return new(postLike.Id,
					   null,
					   postLike.Post?.ToFullResponse(request),
					   postLike.CreatedAtUtc);
		}

		internal PostLikeResponse ToResponseWithoutPost()
		{
			return new(postLike.Id,
					   postLike.User?.ToFullResponse(),
					   null,
					   postLike.CreatedAtUtc);
		}

		public PostLike To(AddPostLikeCommand command)
		{
			return new(
				new(command.Id, command.UserId),
				postLike.CreatedAtUtc);
		}

		public PostLikeId ToResponse(
			AddPostLikeCommand command)
		{
			return postLike.ToId();
		}

		public PostLikeResponse ToResponse(
			GetPostLikeByIdQuery query)
		{
			return postLike.ToFullResponse(query);
		}
	}

	extension(ICollection<PostLike> postLikes)
	{
		public ICollection<PostLikeResponse> ToResponse(
			GetAllPostLikesQuery query)
		{
			return postLikes.Filter(query.Pagination, postLike => postLike.MatchesFilter(query.Filter), postLike => postLike.ToResponseWithoutPost());
		}

		public ICollection<PostLikeResponse> ToResponse(
			GetAllPostLikesForUserQuery query)
		{
			return postLikes.Filter(query.Pagination, postLike => postLike.MatchesFilter(query.Filter), postLike => postLike.ToResponseWithoutUser(query));
		}

		public long ToTotalCountResponse(
			GetAllPostLikesQuery query)
		{
			return postLikes.Count(postLike => postLike.MatchesFilter(query.Filter));
		}

		public long ToTotalCountResponse(
			GetAllPostLikesForUserQuery query)
		{
			return postLikes.Count(postLike => postLike.MatchesFilter(query.Filter));
		}
	}
}
