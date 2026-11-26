using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentMapper
{
	extension(PostComment postComment)
	{
		public PostCommentId ToId()
		{
			return postComment.Id;
		}

		public PostCommentResponse ToFullResponse(UserId currentUserId)
		{
			return postComment.ToFullResponse(currentUserId.Id);
		}

		public PostCommentResponse ToFullResponse(string currentUserId)
		{
			return new(postComment.Id,
					   postComment.UserId,
					   postComment.Content,
					   postComment.Summary,
					   postComment.User?.ToFullResponse(),
					   postComment.Post?.ToFullResponse(currentUserId),
					   postComment.PostCommentImages.ToFullResponse(),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(currentUserId)),
					   postComment.PostCommentLikes.Count,
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		public PostCommentResponse ToResponseWithoutPost(UserId currentUserId)
		{
			return postComment.ToResponseWithoutPost(currentUserId.Id);
		}

		public PostCommentResponse ToResponseWithoutPost(string currentUserId)
		{
			return new(postComment.Id,
					   postComment.UserId,
					   postComment.Content,
					   postComment.Summary,
					   postComment.User?.ToFullResponse(),
					   null,
					   postComment.PostCommentImages.ToFullResponse(),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(currentUserId)),
					   postComment.PostCommentLikes.Count,
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		public PostCommentResponse ToResponseWithoutUser(UserId currentUserId)
		{
			return postComment.ToResponseWithoutUser(currentUserId.Id);
		}

		public PostCommentResponse ToResponseWithoutUser(string currentUserId)
		{
			return new(postComment.Id,
					   postComment.UserId,
					   postComment.Content,
					   postComment.Summary,
					   null,
					   postComment.Post?.ToFullResponse(currentUserId),
					   postComment.PostCommentImages.ToFullResponse(),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(currentUserId)),
					   postComment.PostCommentLikes.Count,
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}
	}

	extension(ICollection<PostComment> postComments)
	{
		public ICollection<PostCommentResponse> ToFullResponse(UserId currentUserId)
		{
			return postComments.ToFullResponse(currentUserId.Id);
		}

		public ICollection<PostCommentResponse> ToFullResponse(string currentUserId)
		{
			return [.. postComments.Select(postComment => postComment.ToFullResponse(currentUserId))];
		}
	}
}
