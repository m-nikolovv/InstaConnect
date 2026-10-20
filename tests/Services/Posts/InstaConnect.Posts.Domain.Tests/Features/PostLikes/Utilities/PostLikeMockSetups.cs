using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;

namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

public static class PostLikeMockSetups
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(PostLike postLike)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(postLike.CreatedAtUtc);
		}
	}

	extension(IPostLikeFactory factory)
	{
		public void SetupCreate(
			AddPostLikeCommand command,
			PostLike postLike)
		{
			factory.SetupCreate(
				command.Id,
				command.UserId,
				postLike.To(command));
		}

		public void SetupCreate(
			PostId id,
			UserId userId,
			PostLike postLike)
		{
			factory
				.Create(
					id,
					userId)
				.ReturnsResponse(postLike);
		}
	}

	extension(IPostLikeCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			DeletePostLikeCommand command,
			PostLikeInclude include,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, postLike, cancellationToken);
		}

		public void SetupGetByIdAsync(
			AddPostLikeCommand command,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(postLike.Id, postLike, cancellationToken);
		}

		public void SetupGetByIdAsync(
			PostLikeId id,
			PostLikeInclude include,
			PostLike? postLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, include, cancellationToken)
				.ReturnsTaskResponse(postLike);
		}

		public void SetupGetByIdAsync(
			PostLikeId id,
			PostLike? postLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, cancellationToken)
				.ReturnsTaskResponse(postLike);
		}

		public void RemoveGetByIdAsync(
			AddPostLikeCommand command,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(postLike.Id, null, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			DeletePostLikeCommand command,
			PostLikeInclude include,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, null, cancellationToken);
		}
	}

	extension(IPostCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddPostLikeCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, post, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			AddPostLikeCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, null, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			DeletePostLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.Id, true, cancellationToken);
		}

		public void RemoveExistsByIdAsync(
			DeletePostLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.Id, false, cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddPostLikeCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.UserId, user, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			AddPostLikeCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.UserId, null, cancellationToken);
		}
	}

	extension(IPostQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllPostLikesQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.Id, query.CurrentUser, post.ToResponse(query), cancellationToken);
		}

		public void RemoveGetByIdAsync(
			GetAllPostLikesQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.Id, query.CurrentUser, null, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			GetPostLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(query.Id.Id, true, cancellationToken);
		}

		public void RemoveExistsByIdAsync(
			GetPostLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(query.Id.Id, false, cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllPostLikesForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.UserId, query.CurrentUser, user.ToResponse(query), cancellationToken);
		}

		public void RemoveGetByIdAsync(
			GetAllPostLikesForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.UserId, query.CurrentUser, null, cancellationToken);
		}
	}

	extension(IPostLikeQueryRepository repository)
	{
		public void SetupGetAllAsync(
			GetAllPostLikesQuery query,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			repository.SetupGetAllAsync(query.Filter, query.Sorting, query.Pagination, query.CurrentUser, postLikes.ToResponse(query), cancellationToken);
		}

		public void SetupGetAllAsync(
			PostLikesFilterQuery filter,
			PostLikesSortingQuery sorting,
			PostLikesPaginationQuery pagination,
			CurrentUserQuery currentUser,
			ICollection<PostLikeResponse> responses,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllAsync(filter, sorting, pagination, currentUser, cancellationToken)
				.ReturnsTaskResponse(responses);
		}

		public void SetupGetTotalCountAsync(
			GetAllPostLikesQuery query,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			repository.SetupGetTotalCountAsync(query.Filter, postLikes.ToTotalCountResponse(query), cancellationToken);
		}

		public void SetupGetTotalCountAsync(
			PostLikesFilterQuery filter,
			long totalCount,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountAsync(filter, cancellationToken)
				.ReturnsTaskResponse(totalCount);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostLikesForUserQuery query,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			repository.SetupGetAllForUserAsync(query.Filter, query.Sorting, query.Pagination, query.CurrentUser, postLikes.ToResponse(query), cancellationToken);
		}

		public void SetupGetAllForUserAsync(
			PostLikesForUserFilterQuery filter,
			PostLikesForUserSortingQuery sorting,
			PostLikesPaginationQuery pagination,
			CurrentUserQuery currentUser,
			ICollection<PostLikeResponse> responses,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllForUserAsync(filter, sorting, pagination, currentUser, cancellationToken)
				.ReturnsTaskResponse(responses);
		}

		public void SetupGetTotalCountForUserAsync(
			GetAllPostLikesForUserQuery query,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			repository.SetupGetTotalCountForUserAsync(query.Filter, postLikes.ToTotalCountResponse(query), cancellationToken);
		}

		public void SetupGetTotalCountForUserAsync(
			PostLikesForUserFilterQuery filter,
			long totalCount,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountForUserAsync(filter, cancellationToken)
				.ReturnsTaskResponse(totalCount);
		}

		public void SetupGetByIdAsync(
			GetPostLikeByIdQuery query,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Id, query.CurrentUser, postLike.ToResponse(query), cancellationToken);
		}

		public void SetupGetByIdAsync(
			PostLikeId id,
			CurrentUserQuery currentUser,
			PostLikeResponse? response,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, currentUser, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void RemoveGetByIdAsync(
			GetPostLikeByIdQuery query,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Id, query.CurrentUser, null, cancellationToken);
		}
	}

	extension(IPostLikeQueryService service)
	{
		public void SetupGetAllAsync(
			GetAllPostLikesQuery query,
			PostLikeCollectionResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostLikesForUserQuery query,
			PostLikeCollectionResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetAllForUserAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetByIdAsync(
			GetPostLikeByIdQuery query,
			PostLikeResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}
	}

	extension(IPostLikeCommandService service)
	{
		public void SetupAddAsync(
			AddPostLikeCommand command,
			PostLikeId id,
			CancellationToken cancellationToken)
		{
			service
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}
}
