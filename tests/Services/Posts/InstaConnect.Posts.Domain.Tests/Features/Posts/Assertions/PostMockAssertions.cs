using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Domain.Tests.Features.Assertions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Posts.Domain.Features.PostImages.Abstractions;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;

public static class PostMockAssertions
{
	extension(IPostFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(
			AddPostCommand command)
		{
			factory.ShouldHaveReceivedOneCreate(
				command.UserId,
				command.Title,
				command.Content);
		}

		public void ShouldHaveReceivedOneCreate(
			UserId userId,
			string title,
			string content)
		{
			factory.ShouldHaveReceivedOne().Create(
				userId,
				title,
				content);
		}
	}

	extension(IPostQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
		GetAllPostsQuery query,
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
			PostsFilterQuery filter,
			PostsSortingQuery sorting,
			PostsPaginationQuery pagination,
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
		GetAllPostsQuery query,
		CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountAsync(
			PostsFilterQuery filter,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			GetAllPostsForUserQuery query,
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
			PostsForUserFilterQuery filter,
			PostsForUserSortingQuery sorting,
			PostsPaginationQuery pagination,
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
		GetAllPostsForUserQuery query,
		CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetTotalCountForUserAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountForUserAsync(
			PostsForUserFilterQuery filter,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountForUserAsync(
				filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetPostByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				query.Id,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			PostId id,
			CurrentUserQuery currentUser,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				currentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			PostId id,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				id,
				cancellationToken);
		}
	}

	extension(IPostCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
			AddPostCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneAddAsync(command.IsPost(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			Post post,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(post, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdatePostCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneUpdateAsync(command.IsPost(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			Post post,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().UpdateAsync(post, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeletePostCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneDeleteAsync(command.IsPost(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			Post post,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(post, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			UpdatePostCommand command,
			PostInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			DeletePostCommand command,
			PostInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			PostId id,
			PostInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			PostId id,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				id,
				cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetAllPostsForUserQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				query.Filter.UserId,
				query.CurrentUser,
				cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			AddPostCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.UserId,
				cancellationToken);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldHaveReceivedOneGetOffsetUtcNow(UpdatePostCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldHaveReceivedOnePublishAsync(
			AddPostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsPostAddedEventRequest(post), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			UpdatePostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsPostUpdatedEventRequest(post), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			DeletePostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsPostDeletedEventRequest(post), cancellationToken);
		}
	}

	extension(IPostQueryService service)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllPostsQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetAllAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			GetAllPostsForUserQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetAllForUserAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetPostByIdQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetByIdAsync(query, cancellationToken);
		}
	}

	extension(IPostCommandService service)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
			AddPostCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdatePostCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().UpdateAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeletePostCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().DeleteAsync(command, cancellationToken);
		}
	}

	extension(IPostSummarizer summarizer)
	{
		public async Task ShouldHaveReceivedOneSummarizeAsync(
			AddPostCommand command,
			CancellationToken cancellationToken)
		{
			await summarizer.ShouldHaveReceivedOneSummarizeAsync(command.IsPost(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSummarizeAsync(
			UpdatePostCommand command,
			CancellationToken cancellationToken)
		{
			await summarizer.ShouldHaveReceivedOneSummarizeAsync(command.IsPost(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSummarizeAsync(
			Post post,
			CancellationToken cancellationToken)
		{
			await summarizer.ShouldHaveReceivedOne().SummarizeAsync(post, cancellationToken);
		}
	}

	extension(IImageHandler imageHandler)
	{
		public async Task ShouldHaveReceivedOneUploadRangeAsync(
			AddPostCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedOneUploadRangeAsync(command.Images, cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroUploadRangeAsync(
			AddPostCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedZeroUploadRangeAsync(command.Images, cancellationToken);
		}
	}

	extension(IPostImageFactory factory)
	{
		public void ShouldHaveReceivedOneCreateRange(
			AddPostCommand command,
			Post post)
		{
			factory.ShouldHaveReceivedOne().CreateRange(post.Id, command.IsImages());
		}

		public void ShouldHaveReceivedZeroCreateRange(
			AddPostCommand command,
			Post post)
		{
			factory.ShouldHaveReceivedZero().CreateRange(post.Id, command.IsImages());
		}
	}

	extension(IPostImageCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneAddRangeAsync(
			AddPostCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddRangeAsync(command.IsPostImages(), cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroAddRangeAsync(
			AddPostCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedZero().AddRangeAsync(command.IsPostImages(), cancellationToken);
		}
	}
}
