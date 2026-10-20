using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMockAssertions
{
	extension(IPostCommentLikeFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(
			AddPostCommentLikeCommand command)
		{
			factory.ShouldHaveReceivedOneCreate(
				command.CommentId,
				command.UserId);
		}

		public void ShouldHaveReceivedOneCreate(
			PostCommentId commentId,
			UserId userId)
		{
			factory.ShouldHaveReceivedOne().Create(
				commentId,
				userId);
		}
	}

	extension(IPostCommentLikeCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			AddPostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				postCommentLike.Id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			DeletePostCommentLikeCommand command,
			PostCommentLikeInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			PostCommentLikeId id,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			PostCommentLikeId id,
			PostCommentLikeInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddPostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneAddAsync(command.IsPostCommentLike(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(postCommentLike, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneDeleteAsync(command.IsPostCommentLike(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(postCommentLike, cancellationToken);
		}
	}

	extension(IPostCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			AddPostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneExistsByIdAsync(
				command.CommentId.Id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneExistsByIdAsync(
				command.Id.CommentId.Id,
				cancellationToken);
		}
	}

	extension(IPostCommentCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			AddPostCommentLikeCommand command,
			PostCommentInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.CommentId,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneExistsByIdAsync(
				command.Id.CommentId,
				cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			AddPostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.UserId,
				cancellationToken);
		}
	}

	extension(IPostQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			GetAllPostCommentLikesQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneExistsByIdAsync(
				query.Filter.CommentId.Id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneExistsByIdAsync(
				query.Id.CommentId.Id,
				cancellationToken);
		}
	}

	extension(IPostCommentQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetAllPostCommentLikesQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				query.Filter.CommentId,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneExistsByIdAsync(
				query.Id.CommentId,
				cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetAllPostCommentLikesForUserQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				query.Filter.UserId,
				query.CurrentUser,
				cancellationToken);
		}
	}

	extension(IPostCommentLikeQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllPostCommentLikesQuery query,
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
			PostCommentLikesFilterQuery filter,
			PostCommentLikesSortingQuery sorting,
			PostCommentLikesPaginationQuery pagination,
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
			GetAllPostCommentLikesQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountAsync(
			PostCommentLikesFilterQuery filter,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			GetAllPostCommentLikesForUserQuery query,
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
			PostCommentLikesForUserFilterQuery filter,
			PostCommentLikesForUserSortingQuery sorting,
			PostCommentLikesPaginationQuery pagination,
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
			GetAllPostCommentLikesForUserQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetTotalCountForUserAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountForUserAsync(
			PostCommentLikesForUserFilterQuery filter,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountForUserAsync(
				filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				query.Id,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			PostCommentLikeId id,
			CurrentUserQuery currentUser,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				currentUser,
				cancellationToken);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldHaveReceivedOnePublishAsync(
			AddPostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsPostCommentLikeAddedEventRequest(postCommentLike), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			DeletePostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsPostCommentLikeDeletedEventRequest(postCommentLike), cancellationToken);
		}
	}

	extension(IPostCommentLikeQueryService service)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllPostCommentLikesQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetAllAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			GetAllPostCommentLikesForUserQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetAllForUserAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetByIdAsync(query, cancellationToken);
		}
	}

	extension(IPostCommentLikeCommandService service)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
			AddPostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().DeleteAsync(command, cancellationToken);
		}
	}
}
