using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;

public static class FollowMockAssertions
{
	extension(IFollowFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(
			AddFollowCommand command)
		{
			factory.ShouldHaveReceivedOneCreate(
				command.FollowerId,
				command.FollowingId);
		}

		public void ShouldHaveReceivedOneCreate(
			UserId followerId,
			UserId followingId)
		{
			factory.ShouldHaveReceivedOne().Create(
				followerId,
				followingId);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByFollowerIdAsync(
			AddFollowCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.FollowerId,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByFollowingIdAsync(
			AddFollowCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.FollowingId,
				cancellationToken);
		}
	}

	extension(IFollowCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			AddFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneExistsByIdAsync(
				follow.Id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			FollowId id,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			DeleteFollowCommand command,
			FollowInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			FollowId id,
			FollowInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddFollowCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneAddAsync(command.IsFollow(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			Follow follow,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(follow, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteFollowCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneDeleteAsync(command.IsFollow(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			Follow follow,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(follow, cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetAllFollowsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				query.Filter.FollowerId,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetAllFollowsForFollowingQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				query.Filter.FollowingId,
				query.CurrentUser,
				cancellationToken);
		}
	}

	extension(IFollowQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllFollowsQuery query,
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
			FollowsFilterQuery filter,
			FollowsSortingQuery sorting,
			FollowsPaginationQuery pagination,
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
			GetAllFollowsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountAsync(
			FollowsFilterQuery filter,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForFollowingAsync(
			GetAllFollowsForFollowingQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetAllForFollowingAsync(
				query.Filter,
				query.Sorting,
				query.Pagination,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForFollowingAsync(
			FollowsForFollowingFilterQuery filter,
			FollowsForFollowingSortingQuery sorting,
			FollowsPaginationQuery pagination,
			CurrentUserQuery currentUser,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllForFollowingAsync(
				filter,
				sorting,
				pagination,
				currentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountForFollowingAsync(
			GetAllFollowsForFollowingQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetTotalCountForFollowingAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountForFollowingAsync(
			FollowsForFollowingFilterQuery filter,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountForFollowingAsync(
				filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetFollowByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				query.Id,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			FollowId id,
			CurrentUserQuery currentUser,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				currentUser,
				cancellationToken);
		}
	}

	extension(IFollowNotificationService notificationService)
	{
		public async Task ShouldHaveReceivedOneAddedAsync(
			AddFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await notificationService.ShouldHaveReceivedOneAddedAsync(command.IsFollowAddedNotificationRequest(follow), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddedAsync(
			FollowAddedNotificationRequest request,
			CancellationToken cancellationToken)
		{
			await notificationService.ShouldHaveReceivedOne().AddedAsync(request, cancellationToken);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldHaveReceivedOnePublishAsync(
			AddFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsFollowAddedEventRequest(follow), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			DeleteFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsFollowDeletedEventRequest(follow), cancellationToken);
		}
	}

	extension(IFollowQueryService service)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllFollowsQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetAllAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForFollowingAsync(
			GetAllFollowsForFollowingQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetAllForFollowingAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetFollowByIdQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetByIdAsync(query, cancellationToken);
		}
	}

	extension(IFollowCommandService service)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
			AddFollowCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteFollowCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().DeleteAsync(command, cancellationToken);
		}
	}
}
