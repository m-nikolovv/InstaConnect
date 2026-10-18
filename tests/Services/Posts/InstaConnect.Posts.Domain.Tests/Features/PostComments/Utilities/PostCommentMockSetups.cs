using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;

public static class PostCommentMockSetups
{
	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(PostComment postComment)
		{
			guidProvider.SetupNewStringGuid(postComment.Id.CommentId);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(PostComment postComment)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(postComment.CreatedAtUtc);
		}
	}

	extension(IPostCommentFactory factory)
	{
		public void SetupCreate(
			AddPostCommentCommand command,
			PostComment postComment)
		{
			factory.SetupCreate(
				command.Id,
				command.UserId,
				command.Content,
				postComment.To(command));
		}

		public void SetupCreate(
			PostId id,
			UserId userId,
			string content,
			PostComment postComment)
		{
			factory
				.Create(
					id,
					userId,
					content)
				.ReturnsResponse(postComment);
		}
	}

	extension(IPostCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddPostCommentCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, post, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			AddPostCommentCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, null, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			UpdatePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.Id, true, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			DeletePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.Id, true, cancellationToken);
		}

		public void RemoveExistsByIdAsync(
			UpdatePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.Id, false, cancellationToken);
		}

		public void RemoveExistsByIdAsync(
			DeletePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.Id, false, cancellationToken);
		}
	}

	extension(IPostCommentCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			UpdatePostCommentCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, postComment, cancellationToken);
		}

		public void SetupGetByIdAsync(
			DeletePostCommentCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, postComment, cancellationToken);
		}

		public void SetupGetByIdAsync(
			PostCommentId id,
			PostCommentInclude include,
			PostComment? postComment,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, include, cancellationToken)
				.ReturnsTaskResponse(postComment);
		}

		public void RemoveGetByIdAsync(
			UpdatePostCommentCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, null, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			DeletePostCommentCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, null, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			PostCommentId id,
			bool exists,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(id, cancellationToken)
				.ReturnsTaskResponse(exists);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddPostCommentCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.UserId, user, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			AddPostCommentCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.UserId, null, cancellationToken);
		}
	}

	extension(IPostQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllPostCommentsQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.Id, query.CurrentUser, post.ToResponse(query), cancellationToken);
		}

		public void RemoveGetByIdAsync(
			GetAllPostCommentsQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.Id, query.CurrentUser, null, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			GetPostCommentByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(query.Id.Id, true, cancellationToken);
		}

		public void RemoveExistsByIdAsync(
			GetPostCommentByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(query.Id.Id, false, cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllPostCommentsForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.UserId, query.CurrentUser, user.ToResponse(query), cancellationToken);
		}

		public void RemoveGetByIdAsync(
			GetAllPostCommentsForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.UserId, query.CurrentUser, null, cancellationToken);
		}
	}

	extension(IPostCommentQueryRepository repository)
	{
		public void SetupGetAllAsync(
			GetAllPostCommentsQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			repository.SetupGetAllAsync(query.Filter, query.Sorting, query.Pagination, query.CurrentUser, postComments.ToResponse(query), cancellationToken);
		}

		public void SetupGetAllAsync(
			PostCommentsFilterQuery filter,
			PostCommentsSortingQuery sorting,
			PostCommentsPaginationQuery pagination,
			CurrentUserQuery currentUser,
			ICollection<PostCommentResponse> responses,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllAsync(filter, sorting, pagination, currentUser, cancellationToken)
				.ReturnsTaskResponse(responses);
		}

		public void SetupGetTotalCountAsync(
			GetAllPostCommentsQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			repository.SetupGetTotalCountAsync(query.Filter, postComments.ToTotalCountResponse(query), cancellationToken);
		}

		public void SetupGetTotalCountAsync(
			PostCommentsFilterQuery filter,
			long totalCount,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountAsync(filter, cancellationToken)
				.ReturnsTaskResponse(totalCount);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostCommentsForUserQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			repository.SetupGetAllForUserAsync(query.Filter, query.Sorting, query.Pagination, query.CurrentUser, postComments.ToResponse(query), cancellationToken);
		}

		public void SetupGetAllForUserAsync(
			PostCommentsForUserFilterQuery filter,
			PostCommentsForUserSortingQuery sorting,
			PostCommentsPaginationQuery pagination,
			CurrentUserQuery currentUser,
			ICollection<PostCommentResponse> responses,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllForUserAsync(filter, sorting, pagination, currentUser, cancellationToken)
				.ReturnsTaskResponse(responses);
		}

		public void SetupGetTotalCountForUserAsync(
			GetAllPostCommentsForUserQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			repository.SetupGetTotalCountForUserAsync(query.Filter, postComments.ToTotalCountResponse(query), cancellationToken);
		}

		public void SetupGetTotalCountForUserAsync(
			PostCommentsForUserFilterQuery filter,
			long totalCount,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountForUserAsync(filter, cancellationToken)
				.ReturnsTaskResponse(totalCount);
		}

		public void SetupGetByIdAsync(
			GetPostCommentByIdQuery query,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Id, query.CurrentUser, postComment.ToResponse(query), cancellationToken);
		}

		public void SetupGetByIdAsync(
			PostCommentId id,
			CurrentUserQuery currentUser,
			PostCommentResponse? response,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, currentUser, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void RemoveGetByIdAsync(
			GetPostCommentByIdQuery query,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Id, query.CurrentUser, null, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			PostCommentId id,
			bool exists,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(id, cancellationToken)
				.ReturnsTaskResponse(exists);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(
			UpdatePostCommentCommand command,
			PostComment postComment)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(postComment.UpdatedAtUtc);
		}
	}

	extension(IPostCommentQueryService service)
	{
		public void SetupGetAllAsync(
			GetAllPostCommentsQuery query,
			PostCommentCollectionResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostCommentsForUserQuery query,
			PostCommentCollectionResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetAllForUserAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetByIdAsync(
			GetPostCommentByIdQuery query,
			PostCommentResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}
	}

	extension(IPostCommentCommandService service)
	{
		public void SetupAddAsync(
			AddPostCommentCommand command,
			PostCommentId id,
			CancellationToken cancellationToken)
		{
			service
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}

		public void SetupUpdateAsync(
			UpdatePostCommentCommand command,
			PostCommentId id,
			CancellationToken cancellationToken)
		{
			service
				.UpdateAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}

	extension(IPostCommentImageFactory factory)
	{
		public void SetupCreateRange(
			AddPostCommentCommand command,
			PostComment postComment)
		{
			factory.SetupCreateRange(
				postComment.Id,
				command.IsImages(),
				postComment.PostCommentImages.To(command));
		}

		public void SetupCreateRange(
			PostCommentId id,
			ICollection<Url> urls,
			ICollection<PostCommentImage> postCommentImages)
		{
			factory
				.CreateRange(id, urls)
				.ReturnsResponse(postCommentImages);
		}
	}
}
