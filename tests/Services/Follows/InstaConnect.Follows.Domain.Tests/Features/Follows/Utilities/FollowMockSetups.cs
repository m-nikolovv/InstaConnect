using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

public static class FollowMockSetups
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(Follow follow)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(follow.CreatedAtUtc);
		}
	}

	extension(IFollowFactory factory)
	{
		public void SetupCreate(
			AddFollowCommand command,
			Follow follow)
		{
			factory.SetupCreate(
				command.FollowerId,
				command.FollowingId,
				follow.To(command));
		}

		public void SetupCreate(
			UserId followerId,
			UserId followingId,
			Follow follow)
		{
			factory
				.Create(
					followerId,
					followingId)
				.ReturnsResponse(follow);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetFollowerByIdAsync(
			AddFollowCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.FollowerId, user, cancellationToken);
		}

		public void SetupGetFollowingByIdAsync(
			AddFollowCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.FollowingId, user, cancellationToken);
		}

		public void RemoveGetFollowerByIdAsync(
			AddFollowCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.FollowerId, null, cancellationToken);
		}

		public void RemoveGetFollowingByIdAsync(
			AddFollowCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.FollowingId, null, cancellationToken);
		}
	}

	extension(IFollowCommandRepository repository)
	{
		public void SetupExistsByIdAsync(
			AddFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(follow.Id, true, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			FollowId id,
			bool exists,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(id, cancellationToken)
				.ReturnsTaskResponse(exists);
		}

		public void RemoveExistsByIdAsync(
			AddFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(follow.Id, false, cancellationToken);
		}

		public void SetupGetByIdAsync(
			DeleteFollowCommand command,
			FollowInclude include,
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, follow, cancellationToken);
		}

		public void SetupGetByIdAsync(
			FollowId id,
			FollowInclude include,
			Follow? follow,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, include, cancellationToken)
				.ReturnsTaskResponse(follow);
		}

		public void RemoveGetByIdAsync(
			DeleteFollowCommand command,
			FollowInclude include,
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, null, cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllFollowsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.FollowerId, query.CurrentUser, user.ToResponse(query), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetAllFollowsForFollowingQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.FollowingId, query.CurrentUser, user.ToResponse(query), cancellationToken);
		}

		public void RemoveGetByIdAsync(
			GetAllFollowsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.FollowerId, query.CurrentUser, null, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			GetAllFollowsForFollowingQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.FollowingId, query.CurrentUser, null, cancellationToken);
		}
	}

	extension(IFollowQueryRepository repository)
	{
		public void SetupGetAllAsync(
			GetAllFollowsQuery query,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			repository.SetupGetAllAsync(query.Filter, query.Sorting, query.Pagination, query.CurrentUser, follows.ToResponse(query), cancellationToken);
		}

		public void SetupGetAllAsync(
			FollowsFilterQuery filter,
			FollowsSortingQuery sorting,
			FollowsPaginationQuery pagination,
			CurrentUserQuery currentUser,
			ICollection<FollowResponse> responses,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllAsync(filter, sorting, pagination, currentUser, cancellationToken)
				.ReturnsTaskResponse(responses);
		}

		public void SetupGetTotalCountAsync(
			GetAllFollowsQuery query,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			repository.SetupGetTotalCountAsync(query.Filter, follows.ToTotalCountResponse(query), cancellationToken);
		}

		public void SetupGetTotalCountAsync(
			FollowsFilterQuery filter,
			long totalCount,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountAsync(filter, cancellationToken)
				.ReturnsTaskResponse(totalCount);
		}

		public void SetupGetAllForFollowingAsync(
			GetAllFollowsForFollowingQuery query,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			repository.SetupGetAllForFollowingAsync(query.Filter, query.Sorting, query.Pagination, query.CurrentUser, follows.ToResponse(query), cancellationToken);
		}

		public void SetupGetAllForFollowingAsync(
			FollowsForFollowingFilterQuery filter,
			FollowsForFollowingSortingQuery sorting,
			FollowsPaginationQuery pagination,
			CurrentUserQuery currentUser,
			ICollection<FollowResponse> responses,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllForFollowingAsync(filter, sorting, pagination, currentUser, cancellationToken)
				.ReturnsTaskResponse(responses);
		}

		public void SetupGetTotalCountForFollowingAsync(
			GetAllFollowsForFollowingQuery query,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			repository.SetupGetTotalCountForFollowingAsync(query.Filter, follows.ToTotalCountResponse(query), cancellationToken);
		}

		public void SetupGetTotalCountForFollowingAsync(
			FollowsForFollowingFilterQuery filter,
			long totalCount,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountForFollowingAsync(filter, cancellationToken)
				.ReturnsTaskResponse(totalCount);
		}

		public void SetupGetByIdAsync(
			GetFollowByIdQuery query,
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Id, query.CurrentUser, follow.ToResponse(query), cancellationToken);
		}

		public void SetupGetByIdAsync(
			FollowId id,
			CurrentUserQuery currentUser,
			FollowResponse? response,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, currentUser, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void RemoveGetByIdAsync(
			GetFollowByIdQuery query,
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Id, query.CurrentUser, null, cancellationToken);
		}
	}

	extension(IFollowQueryService service)
	{
		public void SetupGetAllAsync(
			GetAllFollowsQuery query,
			FollowCollectionResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetAllForFollowingAsync(
			GetAllFollowsForFollowingQuery query,
			FollowCollectionResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetAllForFollowingAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetByIdAsync(
			GetFollowByIdQuery query,
			FollowResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}
	}

	extension(IFollowCommandService service)
	{
		public void SetupAddAsync(
			AddFollowCommand command,
			FollowId id,
			CancellationToken cancellationToken)
		{
			service
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}
}
