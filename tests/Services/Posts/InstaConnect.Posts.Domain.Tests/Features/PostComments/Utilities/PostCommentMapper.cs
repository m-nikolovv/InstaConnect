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
			return post.ToFullResponse(query);
		}
	}

	extension(PostComment postComment)
	{
		internal PostCommentResponse ToFullResponse<TQuery>(
			TQuery request)
			where TQuery : ICurrentUserableQuery
		{
			return new(postComment.Id,
					   postComment.UserId,
					   postComment.Content,
					   postComment.Summary,
					   postComment.User?.ToFullResponse(),
					   postComment.Post?.ToFullResponse(request),
					   postComment.PostCommentImages.ToFullResponse(),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		internal PostCommentResponse ToResponseWithoutUser<TQuery>(
			TQuery request)
			where TQuery : ICurrentUserableQuery
		{
			return new(postComment.Id,
					   postComment.UserId,
					   postComment.Content,
					   postComment.Summary,
					   null,
					   postComment.Post?.ToFullResponse(request),
					   postComment.PostCommentImages.ToFullResponse(),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		internal PostCommentResponse ToResponseWithoutPost<TQuery>(
			TQuery request)
			where TQuery : ICurrentUserableQuery
		{
			return new(postComment.Id,
					   postComment.UserId,
					   postComment.Content,
					   postComment.Summary,
					   postComment.User?.ToFullResponse(),
					   null,
					   postComment.PostCommentImages.ToFullResponse(),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

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
			return postComment.ToFullResponse(query);
		}
	}

	extension(ICollection<PostComment> postComments)
	{
		public ICollection<PostCommentResponse> ToResponse(
			GetAllPostCommentsQuery query)
		{
			return postComments.Filter(query.Pagination, postComment => postComment.MatchesFilter(query.Filter), postComment => postComment.ToResponseWithoutPost(query));
		}

		public ICollection<PostCommentResponse> ToResponse(
			GetAllPostCommentsForUserQuery query)
		{
			return postComments.Filter(query.Pagination, postComment => postComment.MatchesFilter(query.Filter), postComment => postComment.ToResponseWithoutUser(query));
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
