using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Requests.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
	extension(PostCommentId response)
	{
		public bool Matches(
		AddPostCommentCommand command,
		PostComment postComment)
		{
			return response.Matches(postComment.Id);
		}

		public bool Matches(
		UpdatePostCommentCommand command,
		PostComment postComment)
		{
			return response.Matches(postComment.Id);
		}
	}

	extension(PostComment postComment)
	{
		public bool Matches(AddPostCommentCommand command)
		{
			return postComment.Id.Id.Matches(command.Id) &&
				   postComment.Id.CommentId.IsNotNullOrEmptyOrWhiteSpace() &&
				   postComment.UserId.Matches(command.UserId) &&
				   postComment.Content == command.Content &&
				   postComment.CreatedAtUtc != default &&
				   postComment.UpdatedAtUtc != default;
		}

		public bool Matches(UpdatePostCommentCommand command)
		{
			return postComment.Id.Matches(command.Id) &&
				   postComment.UserId.Matches(command.UserId) &&
				   postComment.Content == command.Content &&
				   postComment.CreatedAtUtc != default &&
				   postComment.UpdatedAtUtc != default;
		}

		public bool Matches(DeletePostCommentCommand command)
		{
			return postComment.Id.Matches(command.Id) &&
				   postComment.UserId.Matches(command.UserId) &&
				   postComment.Content.IsNotNullOrEmptyOrWhiteSpace() &&
				   postComment.CreatedAtUtc != default &&
				   postComment.UpdatedAtUtc != default;
		}

		public bool MatchesFilter(PostCommentsFilterQuery query)
		{
			return postComment.Id.Id.Matches(query.Id) &&
				   postComment.User.MatchesFilter(query);
		}

		public bool MatchesFilter(PostCommentsForUserFilterQuery query)
		{
			return postComment.UserId.Matches(query.UserId);
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(PostCommentsFilterQuery query)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(query.UserName.Value);
		}
	}

	extension(PostCommentAddedEventRequest p)
	{
		public bool Matches(AddPostCommentCommand command, PostComment postComment)
		{
			return p.PostComment.Matches(command, postComment);
		}
	}

	extension(PostCommentUpdatedEventRequest p)
	{
		public bool Matches(UpdatePostCommentCommand command, PostComment postComment)
		{
			return p.PostComment.Matches(command, postComment);
		}
	}

	extension(PostCommentDeletedEventRequest r)
	{
		public bool Matches(DeletePostCommentCommand command, PostComment postComment)
		{
			return r.PostComment.Matches(command, postComment);
		}
	}

	extension(PostCommentEventRequest request)
	{
		public bool Matches(AddPostCommentCommand command, PostComment? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id) &&
				   request.CommentId.EqualsOrdinalIgnoreCase(entity.Id.CommentId) &&
				   request.UserId.EqualsOrdinalIgnoreCase(command.UserId.Id) &&
				   request.Content == command.Content &&
				   request.User.Matches(command, entity.User) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(UpdatePostCommentCommand command, PostComment? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id.Id) &&
				   request.CommentId.EqualsOrdinalIgnoreCase(command.Id.CommentId) &&
				   request.UserId.EqualsOrdinalIgnoreCase(command.UserId.Id) &&
				   request.Content == command.Content &&
				   request.User.Matches(command, entity.User) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeletePostCommentCommand command, PostComment? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id.Id) &&
				   request.CommentId.EqualsOrdinalIgnoreCase(command.Id.CommentId) &&
				   request.UserId.EqualsOrdinalIgnoreCase(command.UserId.Id) &&
				   request.Content == entity.Content &&
				   request.User.Matches(command, entity.User) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(UserEventRequest request)
	{
		public bool Matches(AddPostCommentCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.UserId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(UpdatePostCommentCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.UserId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeletePostCommentCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.UserId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(PostCommentResponse? response)
	{
		public bool MatchesFull<TQuery>(TQuery request, PostComment? postComment)
		where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)) &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(postComment.User) &&
				   response.Post.MatchesFull(request, postComment.Post);
		}

		public bool MatchesWithoutUser<TQuery>(TQuery request, PostComment? postComment)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)) &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User == null &&
				   response.Post.MatchesFull(request, postComment.Post);
		}

		public bool MatchesWithoutPost<TQuery>(TQuery request, PostComment? postComment)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)) &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(postComment.User) &&
				   response.Post == null;
		}

		public bool Matches(GetPostCommentByIdQuery query, PostComment postComment)
		{
			return response.MatchesFull(query, postComment);
		}
	}

	extension(PostCommentCollectionResponse response)
	{
		public bool MatchesWithoutUser<TQuery>(
		TQuery request,
		Func<PostCommentResponse, PostComment, bool> matches,
		Func<PostComment, bool> matchesFilter,
		Post post,
		ICollection<PostComment> postComments)
		where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostCommentsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postComments.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Post.MatchesFull(request, post) &&
				   response.PostComments.MatchesCollection(request.Pagination,
													postComments,
													response => response.Id,
													postComment => postComment.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutUser<TQuery>(
			TQuery request,
			Func<PostCommentResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			Post post,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostCommentsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postComments.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Post.MatchesFull(request, post) &&
				   response.PostComments.MatchesSortedCollection(request.Pagination,
														  postComments,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutPost<TQuery>(
			TQuery request,
			Func<PostCommentResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			User user,
			ICollection<PostComment> postComments)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostCommentsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postComments.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostComments.MatchesCollection(request.Pagination,
													postComments,
													response => response.Id,
													postComment => postComment.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutPost<TQuery>(
			TQuery request,
			Func<PostCommentResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			User user,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostCommentsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postComments.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostComments.MatchesSortedCollection(request.Pagination,
														  postComments,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool Matches(
		GetAllPostCommentsQuery query,
		Post post,
		ICollection<PostComment> postComments)
		{
			return response.MatchesWithoutUser(
					   query,
					   (response, postComment) => response.MatchesWithoutPost(query, postComment),
					   postComment => postComment.MatchesFilter(query.Filter),
					   post,
					   postComments);
		}

		public bool Matches(
			GetAllPostCommentsQuery query,
			Post post,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			return response.MatchesWithoutUser(
					   query,
					   (response, postComment) => response.MatchesWithoutPost(query, postComment),
					   postComment => postComment.MatchesFilter(query.Filter),
					   post,
					   postComments,
					   termTransformer);
		}

		public bool Matches(
		GetAllPostCommentsForUserQuery query,
		User user,
		ICollection<PostComment> postComments)
		{
			return response.MatchesWithoutPost(
					   query,
					   (response, postComment) => response.MatchesWithoutUser(query, postComment),
					   postComment => postComment.MatchesFilter(query.Filter),
					   user,
					   postComments);
		}

		public bool Matches(
			GetAllPostCommentsForUserQuery query,
			User user,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			return response.MatchesWithoutPost(
					   query,
					   (response, postComment) => response.MatchesWithoutUser(query, postComment),
					   postComment => postComment.MatchesFilter(query.Filter),
					   user,
					   postComments,
					   termTransformer);
		}
	}
}
