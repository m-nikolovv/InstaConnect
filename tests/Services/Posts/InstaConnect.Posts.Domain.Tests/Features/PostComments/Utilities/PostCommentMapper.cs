namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;

public static class PostCommentMapper
{
	extension(User user)
	{
		public UserResponse ToResponse(
			GetAllPostCommentsForUserQuery query)
		{
			return user.ToFullResponse();
		}
	}

	extension(Post post)
	{
		public PostResponse ToResponse(
			GetAllPostCommentsQuery query)
		{
			return post.ToFullResponse(query.CurrentUser.Id);
		}
	}

	extension(PostComment postComment)
	{
		public PostComment To(AddPostCommentCommand command)
		{
			return new(postComment.Id,
					   command.Content,
					   new(string.Empty),
					   command.UserId,
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		public PostCommentId ToResponse(
			AddPostCommentCommand command)
		{
			return postComment.ToId();
		}

		public PostCommentId ToResponse(
			UpdatePostCommentCommand command)
		{
			return postComment.ToId();
		}

		public PostCommentResponse ToResponse(
			GetPostCommentByIdQuery query)
		{
			return postComment.ToFullResponse(query.CurrentUser.Id);
		}
	}

	extension(ICollection<PostComment> postComments)
	{
		public ICollection<PostCommentResponse> ToResponse(
			GetAllPostCommentsQuery query)
		{
			return postComments.Filter(query.Pagination, postComment => postComment.MatchesFilter(query.Filter), postComment => postComment.ToResponseWithoutPost(query.CurrentUser.Id));
		}

		public ICollection<PostCommentResponse> ToResponse(
			GetAllPostCommentsForUserQuery query)
		{
			return postComments.Filter(query.Pagination, postComment => postComment.MatchesFilter(query.Filter), postComment => postComment.ToResponseWithoutUser(query.CurrentUser.Id));
		}

		public long ToTotalCountResponse(
			GetAllPostCommentsQuery query)
		{
			return postComments.Count(postComment => postComment.MatchesFilter(query.Filter));
		}

		public long ToTotalCountResponse(
			GetAllPostCommentsForUserQuery query)
		{
			return postComments.Count(postComment => postComment.MatchesFilter(query.Filter));
		}
	}

	extension(ICollection<PostCommentImage> postCommentImages)
	{
		public ICollection<PostCommentImage> To(AddPostCommentCommand command)
		{
			return [.. postCommentImages.Zip(command.Images, (postCommentImage, formFile) => new PostCommentImage(
				postCommentImage.Id,
				formFile.GetUrl(),
				postCommentImage.CreatedAtUtc))];
		}
	}
}
