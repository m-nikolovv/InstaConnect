using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMapper
{
	extension(User user)
	{
		public UserResponse ToResponse(
			GetAllPostCommentLikesForUserQuery query)
		{
			return user.ToFullResponse();
		}
	}

	extension(PostComment postComment)
	{
		public PostCommentResponse ToResponse(
			GetAllPostCommentLikesQuery query)
		{
			return postComment.ToFullResponse(query);
		}
	}

	extension(PostCommentLike postCommentLike)
	{
		internal PostCommentLikeResponse ToFullResponse<TQuery>(
			TQuery request)
			where TQuery : ICurrentUserableQuery
		{
			return new(postCommentLike.Id,
					   postCommentLike.User?.ToFullResponse(),
					   postCommentLike.PostComment?.ToFullResponse(request),
					   postCommentLike.CreatedAtUtc);
		}

		internal PostCommentLikeResponse ToResponseWithoutUser<TQuery>(
			TQuery request)
			where TQuery : ICurrentUserableQuery
		{
			return new(postCommentLike.Id,
					   null,
					   postCommentLike.PostComment?.ToFullResponse(request),
					   postCommentLike.CreatedAtUtc);
		}

		internal PostCommentLikeResponse ToResponseWithoutPostComment()
		{
			return new(postCommentLike.Id,
					   postCommentLike.User?.ToFullResponse(),
					   null,
					   postCommentLike.CreatedAtUtc);
		}

		public PostCommentLike To(AddPostCommentLikeCommand command)
		{
			return new(
				new(command.CommentId, command.UserId),
				postCommentLike.CreatedAtUtc);
		}

		public PostCommentLikeId ToResponse(
			AddPostCommentLikeCommand command)
		{
			return postCommentLike.ToId();
		}

		public PostCommentLikeResponse ToResponse(
			GetPostCommentLikeByIdQuery query)
		{
			return postCommentLike.ToFullResponse(query);
		}
	}

	extension(ICollection<PostCommentLike> postCommentLikes)
	{
		public ICollection<PostCommentLikeResponse> ToResponse(
			GetAllPostCommentLikesQuery query)
		{
			return postCommentLikes.Filter(query.Pagination, postCommentLike => postCommentLike.MatchesFilter(query.Filter), postCommentLike => postCommentLike.ToResponseWithoutPostComment());
		}

		public ICollection<PostCommentLikeResponse> ToResponse(
			GetAllPostCommentLikesForUserQuery query)
		{
			return postCommentLikes.Filter(query.Pagination, postCommentLike => postCommentLike.MatchesFilter(query.Filter), postCommentLike => postCommentLike.ToResponseWithoutUser(query));
		}

		public long ToTotalCountResponse(
			GetAllPostCommentLikesQuery query)
		{
			return postCommentLikes.Count(postCommentLike => postCommentLike.MatchesFilter(query.Filter));
		}

		public long ToTotalCountResponse(
			GetAllPostCommentLikesForUserQuery query)
		{
			return postCommentLikes.Count(postCommentLike => postCommentLike.MatchesFilter(query.Filter));
		}
	}
}
