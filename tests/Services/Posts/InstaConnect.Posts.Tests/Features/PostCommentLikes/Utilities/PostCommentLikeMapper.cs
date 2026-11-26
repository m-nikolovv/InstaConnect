using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMapper
{
	extension(PostCommentLike postCommentLike)
	{
		public PostCommentLikeId ToId()
		{
			return postCommentLike.Id;
		}

		public PostCommentLikeResponse ToFullResponse(UserId currentUserId)
		{
			return postCommentLike.ToFullResponse(currentUserId.Id);
		}

		public PostCommentLikeResponse ToFullResponse(string currentUserId)
		{
			return new(postCommentLike.Id,
					   postCommentLike.User?.ToFullResponse(),
					   postCommentLike.PostComment?.ToFullResponse(currentUserId),
					   postCommentLike.CreatedAtUtc);
		}

		public PostCommentLikeResponse ToResponseWithoutPostComment()
		{
			return new(postCommentLike.Id,
					   postCommentLike.User?.ToFullResponse(),
					   null,
					   postCommentLike.CreatedAtUtc);
		}

		public PostCommentLikeResponse ToResponseWithoutUser(UserId currentUserId)
		{
			return postCommentLike.ToResponseWithoutUser(currentUserId.Id);
		}

		public PostCommentLikeResponse ToResponseWithoutUser(string currentUserId)
		{
			return new(postCommentLike.Id,
					   null,
					   postCommentLike.PostComment?.ToFullResponse(currentUserId),
					   postCommentLike.CreatedAtUtc);
		}
	}

	extension(ICollection<PostCommentLike> postCommentLikes)
	{
		public ICollection<PostCommentLikeResponse> ToFullResponse(UserId currentUserId)
		{
			return postCommentLikes.ToFullResponse(currentUserId.Id);
		}

		public ICollection<PostCommentLikeResponse> ToFullResponse(string currentUserId)
		{
			return [.. postCommentLikes.Select(postCommentLike => postCommentLike.ToFullResponse(currentUserId))];
		}
	}
}
