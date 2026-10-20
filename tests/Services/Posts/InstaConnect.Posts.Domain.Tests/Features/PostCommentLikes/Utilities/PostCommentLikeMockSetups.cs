using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMockSetups
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(PostCommentLike postCommentLike)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(postCommentLike.CreatedAtUtc);
		}
	}

	extension(IPostCommentLikeFactory factory)
	{
		public void SetupCreate(
			AddPostCommentLikeCommand command,
			PostCommentLike postCommentLike)
		{
			factory.SetupCreate(
				command.CommentId,
				command.UserId,
				postCommentLike.To(command));
		}

		public void SetupCreate(
			PostCommentId commentId,
			UserId userId,
			PostCommentLike postCommentLike)
		{
			factory
				.Create(
					commentId,
					userId)
				.ReturnsResponse(postCommentLike);
		}
	}

	extension(IPostCommentLikeCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			DeletePostCommentLikeCommand command,
			PostCommentLikeInclude include,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, postCommentLike, cancellationToken);
		}

		public void SetupGetByIdAsync(
			AddPostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(postCommentLike.Id, postCommentLike, cancellationToken);
		}

		public void SetupGetByIdAsync(
			PostCommentLikeId id,
			PostCommentLikeInclude include,
			PostCommentLike? postCommentLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, include, cancellationToken)
				.ReturnsTaskResponse(postCommentLike);
		}

		public void SetupGetByIdAsync(
			PostCommentLikeId id,
			PostCommentLike? postCommentLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, cancellationToken)
				.ReturnsTaskResponse(postCommentLike);
		}

		public void RemoveGetByIdAsync(
			AddPostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(postCommentLike.Id, null, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			DeletePostCommentLikeCommand command,
			PostCommentLikeInclude include,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, null, cancellationToken);
		}
	}

	extension(IPostCommandRepository repository)
	{
		public void SetupExistsByIdAsync(
			AddPostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.CommentId.Id, true, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.CommentId.Id, true, cancellationToken);
		}

		public void RemoveExistsByIdAsync(
			AddPostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.CommentId.Id, false, cancellationToken);
		}

		public void RemoveExistsByIdAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.CommentId.Id, false, cancellationToken);
		}
	}

	extension(IPostCommentCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddPostCommentLikeCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.CommentId, include, postComment, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			AddPostCommentLikeCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.CommentId, include, null, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.CommentId, true, cancellationToken);
		}

		public void RemoveExistsByIdAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.CommentId, false, cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddPostCommentLikeCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.UserId, user, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			AddPostCommentLikeCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.UserId, null, cancellationToken);
		}
	}

	extension(IPostQueryRepository repository)
	{
		public void SetupExistsByIdAsync(
			GetAllPostCommentLikesQuery query,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(query.Filter.CommentId.Id, true, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(query.Id.CommentId.Id, true, cancellationToken);
		}

		public void RemoveExistsByIdAsync(
			GetAllPostCommentLikesQuery query,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(query.Filter.CommentId.Id, false, cancellationToken);
		}

		public void RemoveExistsByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(query.Id.CommentId.Id, false, cancellationToken);
		}
	}

	extension(IPostCommentQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllPostCommentLikesQuery query,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.CommentId, query.CurrentUser, postComment.ToResponse(query), cancellationToken);
		}

		public void RemoveGetByIdAsync(
			GetAllPostCommentLikesQuery query,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.CommentId, query.CurrentUser, null, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(query.Id.CommentId, true, cancellationToken);
		}

		public void RemoveExistsByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(query.Id.CommentId, false, cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllPostCommentLikesForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.UserId, query.CurrentUser, user.ToResponse(query), cancellationToken);
		}

		public void RemoveGetByIdAsync(
			GetAllPostCommentLikesForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.UserId, query.CurrentUser, null, cancellationToken);
		}
	}

	extension(IPostCommentLikeQueryRepository repository)
	{
		public void SetupGetAllAsync(
			GetAllPostCommentLikesQuery query,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			repository.SetupGetAllAsync(query.Filter, query.Sorting, query.Pagination, query.CurrentUser, postCommentLikes.ToResponse(query), cancellationToken);
		}

		public void SetupGetAllAsync(
			PostCommentLikesFilterQuery filter,
			PostCommentLikesSortingQuery sorting,
			PostCommentLikesPaginationQuery pagination,
			CurrentUserQuery currentUser,
			ICollection<PostCommentLikeResponse> responses,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllAsync(filter, sorting, pagination, currentUser, cancellationToken)
				.ReturnsTaskResponse(responses);
		}

		public void SetupGetTotalCountAsync(
			GetAllPostCommentLikesQuery query,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			repository.SetupGetTotalCountAsync(query.Filter, postCommentLikes.ToTotalCountResponse(query), cancellationToken);
		}

		public void SetupGetTotalCountAsync(
			PostCommentLikesFilterQuery filter,
			long totalCount,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountAsync(filter, cancellationToken)
				.ReturnsTaskResponse(totalCount);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostCommentLikesForUserQuery query,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			repository.SetupGetAllForUserAsync(query.Filter, query.Sorting, query.Pagination, query.CurrentUser, postCommentLikes.ToResponse(query), cancellationToken);
		}

		public void SetupGetAllForUserAsync(
			PostCommentLikesForUserFilterQuery filter,
			PostCommentLikesForUserSortingQuery sorting,
			PostCommentLikesPaginationQuery pagination,
			CurrentUserQuery currentUser,
			ICollection<PostCommentLikeResponse> responses,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllForUserAsync(filter, sorting, pagination, currentUser, cancellationToken)
				.ReturnsTaskResponse(responses);
		}

		public void SetupGetTotalCountForUserAsync(
			GetAllPostCommentLikesForUserQuery query,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			repository.SetupGetTotalCountForUserAsync(query.Filter, postCommentLikes.ToTotalCountResponse(query), cancellationToken);
		}

		public void SetupGetTotalCountForUserAsync(
			PostCommentLikesForUserFilterQuery filter,
			long totalCount,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountForUserAsync(filter, cancellationToken)
				.ReturnsTaskResponse(totalCount);
		}

		public void SetupGetByIdAsync(
			GetPostCommentLikeByIdQuery query,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Id, query.CurrentUser, postCommentLike.ToResponse(query), cancellationToken);
		}

		public void SetupGetByIdAsync(
			PostCommentLikeId id,
			CurrentUserQuery currentUser,
			PostCommentLikeResponse? response,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, currentUser, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void RemoveGetByIdAsync(
			GetPostCommentLikeByIdQuery query,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Id, query.CurrentUser, null, cancellationToken);
		}
	}

	extension(IPostCommentLikeQueryService service)
	{
		public void SetupGetAllAsync(
			GetAllPostCommentLikesQuery query,
			PostCommentLikeCollectionResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostCommentLikesForUserQuery query,
			PostCommentLikeCollectionResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetAllForUserAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetByIdAsync(
			GetPostCommentLikeByIdQuery query,
			PostCommentLikeResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}
	}

	extension(IPostCommentLikeCommandService service)
	{
		public void SetupAddAsync(
			AddPostCommentLikeCommand command,
			PostCommentLikeId id,
			CancellationToken cancellationToken)
		{
			service
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}
}
