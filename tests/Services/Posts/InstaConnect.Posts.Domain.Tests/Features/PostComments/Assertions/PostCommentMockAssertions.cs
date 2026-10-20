using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Domain.Tests.Features.Assertions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;

public static class PostCommentMockAssertions
{
	extension(IPostCommentFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(
			AddPostCommentCommand command)
		{
			factory.ShouldHaveReceivedOneCreate(
				command.Id,
				command.UserId,
				command.Content);
		}

		public void ShouldHaveReceivedOneCreate(
			PostId id,
			UserId userId,
			string content)
		{
			factory.ShouldHaveReceivedOne().Create(
				id,
				userId,
				content);
		}
	}

	extension(IPostCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			AddPostCommentCommand command,
			PostInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			UpdatePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneExistsByIdAsync(
				command.Id.Id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			DeletePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneExistsByIdAsync(
				command.Id.Id,
				cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			AddPostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.UserId,
				cancellationToken);
		}
	}

	extension(IPostCommentCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			UpdatePostCommentCommand command,
			PostCommentInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			DeletePostCommentCommand command,
			PostCommentInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			PostCommentId id,
			PostCommentInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			PostCommentId id,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddPostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneAddAsync(command.IsPostComment(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(postComment, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdatePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneUpdateAsync(command.IsPostComment(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().UpdateAsync(postComment, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeletePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneDeleteAsync(command.IsPostComment(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(postComment, cancellationToken);
		}
	}

	extension(IPostQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetAllPostCommentsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				query.Filter.Id,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			GetPostCommentByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneExistsByIdAsync(
				query.Id.Id,
				cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetAllPostCommentsForUserQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				query.Filter.UserId,
				query.CurrentUser,
				cancellationToken);
		}
	}

	extension(IPostCommentQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllPostCommentsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetAllAsync(
				query.Filter,
				query.Sorting,
				query.Pagination,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllAsync(
			PostCommentsFilterQuery filter,
			PostCommentsSortingQuery sorting,
			PostCommentsPaginationQuery pagination,
			CurrentUserQuery currentUser,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllAsync(
				filter,
				sorting,
				pagination,
				currentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountAsync(
			GetAllPostCommentsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountAsync(
			PostCommentsFilterQuery filter,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			GetAllPostCommentsForUserQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetAllForUserAsync(
				query.Filter,
				query.Sorting,
				query.Pagination,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			PostCommentsForUserFilterQuery filter,
			PostCommentsForUserSortingQuery sorting,
			PostCommentsPaginationQuery pagination,
			CurrentUserQuery currentUser,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllForUserAsync(
				filter,
				sorting,
				pagination,
				currentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountForUserAsync(
			GetAllPostCommentsForUserQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetTotalCountForUserAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountForUserAsync(
			PostCommentsForUserFilterQuery filter,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountForUserAsync(
				filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetPostCommentByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				query.Id,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			PostCommentId id,
			CurrentUserQuery currentUser,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				currentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			PostCommentId id,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				id,
				cancellationToken);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldHaveReceivedOneGetOffsetUtcNow(UpdatePostCommentCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldHaveReceivedOnePublishAsync(
			AddPostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsPostCommentAddedEventRequest(postComment), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			UpdatePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsPostCommentUpdatedEventRequest(postComment), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			DeletePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsPostCommentDeletedEventRequest(postComment), cancellationToken);
		}
	}

	extension(IPostCommentQueryService service)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllPostCommentsQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetAllAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			GetAllPostCommentsForUserQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetAllForUserAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetPostCommentByIdQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetByIdAsync(query, cancellationToken);
		}
	}

	extension(IPostCommentCommandService service)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
			AddPostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdatePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().UpdateAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeletePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().DeleteAsync(command, cancellationToken);
		}
	}

	extension(IPostCommentSummarizer summarizer)
	{
		public async Task ShouldHaveReceivedOneSummarizeAsync(
			AddPostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await summarizer.ShouldHaveReceivedOneSummarizeAsync(command.IsPostComment(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSummarizeAsync(
			UpdatePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await summarizer.ShouldHaveReceivedOneSummarizeAsync(command.IsPostComment(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSummarizeAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await summarizer.ShouldHaveReceivedOne().SummarizeAsync(postComment, cancellationToken);
		}
	}

	extension(IImageHandler imageHandler)
	{
		public async Task ShouldHaveReceivedOneUploadRangeAsync(
			AddPostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedOneUploadRangeAsync(command.Images, cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroUploadRangeAsync(
			AddPostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedZeroUploadRangeAsync(command.Images, cancellationToken);
		}
	}

	extension(IPostCommentImageFactory factory)
	{
		public void ShouldHaveReceivedOneCreateRange(
			AddPostCommentCommand command,
			PostComment postComment)
		{
			factory.ShouldHaveReceivedOne().CreateRange(postComment.Id, command.IsImages());
		}

		public void ShouldHaveReceivedZeroCreateRange(
			AddPostCommentCommand command,
			PostComment postComment)
		{
			factory.ShouldHaveReceivedZero().CreateRange(postComment.Id, command.IsImages());
		}
	}

	extension(IPostCommentImageCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneAddRangeAsync(
			AddPostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddRangeAsync(command.IsPostCommentImages(), cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroAddRangeAsync(
			AddPostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedZero().AddRangeAsync(command.IsPostCommentImages(), cancellationToken);
		}
	}
}
