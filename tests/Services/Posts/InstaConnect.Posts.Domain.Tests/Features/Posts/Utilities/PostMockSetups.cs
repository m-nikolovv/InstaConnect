using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

public static class PostMockSetups
{
	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(Post post)
		{
			guidProvider.SetupNewStringGuid(post.Id.Id);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(Post post)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(post.CreatedAtUtc);
		}
	}

	extension(IPostFactory factory)
	{
		public void SetupCreate(
			AddPostCommand command,
			Post post)
		{
			factory.SetupCreate(
				command.UserId,
				command.Title,
				command.Content,
				post.To(command));
		}

		public void SetupCreate(
			UserId userId,
			string title,
			string content,
			Post post)
		{
			factory
				.Create(
					userId,
					title,
					content)
				.ReturnsResponse(post);
		}
	}

	extension(IPostQueryRepository service)
	{
		public void SetupGetAllAsync(
		GetAllPostsQuery query,
		ICollection<Post> posts,
		CancellationToken cancellationToken)
		{
			service.SetupGetAllAsync(query.Filter, query.Sorting, query.Pagination, query.CurrentUser, posts.ToResponse(query), cancellationToken);
		}

		public void SetupGetAllAsync(
			PostsFilterQuery filter,
			PostsSortingQuery sorting,
			PostsPaginationQuery pagination,
			CurrentUserQuery currentUser,
			ICollection<PostResponse> responses,
			CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(filter, sorting, pagination, currentUser, cancellationToken)
				.ReturnsTaskResponse(responses);
		}

		public void SetupGetTotalCountAsync(
		GetAllPostsQuery query,
		ICollection<Post> posts,
		CancellationToken cancellationToken)
		{
			service.SetupGetTotalCountAsync(query.Filter, posts.ToTotalCountResponse(query), cancellationToken);
		}

		public void SetupGetTotalCountAsync(
			PostsFilterQuery filter,
			long totalCount,
			CancellationToken cancellationToken)
		{
			service
				.GetTotalCountAsync(filter, cancellationToken)
				.ReturnsTaskResponse(totalCount);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostsForUserQuery query,
			User user,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			service.SetupGetAllForUserAsync(query.Filter, query.Sorting, query.Pagination, query.CurrentUser, posts.ToResponse(query), cancellationToken);
		}

		public void SetupGetAllForUserAsync(
			PostsForUserFilterQuery filter,
			PostsForUserSortingQuery sorting,
			PostsPaginationQuery pagination,
			CurrentUserQuery currentUser,
			ICollection<PostResponse> responses,
			CancellationToken cancellationToken)
		{
			service
				.GetAllForUserAsync(filter, sorting, pagination, currentUser, cancellationToken)
				.ReturnsTaskResponse(responses);
		}

		public void SetupGetTotalCountForUserAsync(
		GetAllPostsForUserQuery query,
		ICollection<Post> posts,
		CancellationToken cancellationToken)
		{
			service.SetupGetTotalCountForUserAsync(query.Filter, posts.ToTotalCountResponse(query), cancellationToken);
		}

		public void SetupGetTotalCountForUserAsync(
			PostsForUserFilterQuery filter,
			long totalCount,
			CancellationToken cancellationToken)
		{
			service
				.GetTotalCountForUserAsync(filter, cancellationToken)
				.ReturnsTaskResponse(totalCount);
		}

		public void SetupGetByIdAsync(
			GetPostByIdQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			service.SetupGetByIdAsync(query.Id, query.CurrentUser, post.ToResponse(query), cancellationToken);
		}

		public void SetupGetByIdAsync(
			PostId id,
			CurrentUserQuery currentUser,
			PostResponse? response,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(id, currentUser, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void RemoveGetByIdAsync(
			GetPostByIdQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			service.SetupGetByIdAsync(query.Id, query.CurrentUser, null, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			PostId id,
			bool exists,
			CancellationToken cancellationToken)
		{
			service
				.ExistsByIdAsync(id, cancellationToken)
				.ReturnsTaskResponse(exists);
		}
	}

	extension(IPostCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			UpdatePostCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, post, cancellationToken);
		}

		public void SetupGetByIdAsync(
			DeletePostCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, post, cancellationToken);
		}

		public void SetupGetByIdAsync(
			PostId id,
			PostInclude include,
			Post? post,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, include, cancellationToken)
				.ReturnsTaskResponse(post);
		}

		public void RemoveGetByIdAsync(
			UpdatePostCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, null, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			DeletePostCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, null, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			PostId id,
			bool exists,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(id, cancellationToken)
				.ReturnsTaskResponse(exists);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllPostsForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.UserId, query.CurrentUser, user.ToResponse(query), cancellationToken);
		}

		public void RemoveGetByIdAsync(
			GetAllPostsForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.UserId, query.CurrentUser, null, cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddPostCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.UserId, user, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			AddPostCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.UserId, null, cancellationToken);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(
			UpdatePostCommand command,
			Post post)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(post.UpdatedAtUtc);
		}
	}

	extension(IPostQueryService service)
	{
		public void SetupGetAllAsync(
			GetAllPostsQuery query,
			PostCollectionResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostsForUserQuery query,
			PostCollectionResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetAllForUserAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetByIdAsync(
			GetPostByIdQuery query,
			PostResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}
	}

	extension(IPostCommandService service)
	{
		public void SetupAddAsync(
			AddPostCommand command,
			PostId id,
			CancellationToken cancellationToken)
		{
			service
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}

		public void SetupUpdateAsync(
			UpdatePostCommand command,
			PostId id,
			CancellationToken cancellationToken)
		{
			service
				.UpdateAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}

	extension(IPostImageFactory factory)
	{
		public void SetupCreateRange(
			AddPostCommand command,
			Post post)
		{
			factory.SetupCreateRange(
				post.Id,
				command.IsImages(),
				post.PostImages.To(command));
		}

		public void SetupCreateRange(
			PostId id,
			ICollection<Url> urls,
			ICollection<PostImage> postImages)
		{
			factory
				.CreateRange(id, urls)
				.ReturnsResponse(postImages);
		}
	}
}
