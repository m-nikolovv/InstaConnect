using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Tests.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Extensions;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Entities;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Events.Features.PostCommentImages;
using InstaConnect.Posts.Events.Features.PostComments;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Extensions;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
	extension(PostCommentAddedEventRequest r)
	{
		public bool Matches(AddPostCommentCommandRequest request, PostComment entity)
		{
			return r.PostComment.Matches(request, entity);
		}
	}

	extension(PostCommentUpdatedEventRequest r)
	{
		public bool Matches(UpdatePostCommentCommandRequest request, PostComment entity)
		{
			return r.PostComment.Matches(request, entity);
		}
	}

	extension(PostCommentDeletedEventRequest r)
	{
		public bool Matches(DeletePostCommentCommandRequest request, PostComment entity)
		{
			return r.PostComment.Matches(request, entity);
		}
	}

	extension(PostCommentEventRequest r)
	{
		public bool Matches(AddPostCommentCommandRequest request, PostComment? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.CommentId.EqualsOrdinalIgnoreCase(entity.Id.CommentId) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.Content == request.Content &&
				   r.Summary == entity.GetSummary(request) &&
				   r.User.Matches(request, entity.User) &&
				   r.PostCommentImages.Matches(request, entity.PostCommentImages) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(UpdatePostCommentCommandRequest request, PostComment? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.CommentId.EqualsOrdinalIgnoreCase(request.CommentId) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.Content == request.Content &&
				   r.Summary == entity.GetSummary(request) &&
				   r.User.Matches(request, entity.User) &&
				   r.PostCommentImages.Matches(request, entity.PostCommentImages) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeletePostCommentCommandRequest request, PostComment? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.CommentId.EqualsOrdinalIgnoreCase(request.CommentId) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.Content == entity.Content &&
				   r.Summary.EqualsOrdinalIgnoreCase(entity.Summary.Value) &&
				   r.User.Matches(request, entity.User) &&
				   r.PostCommentImages.Matches(request, entity.PostCommentImages) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(PostCommentImageEventRequest r)
	{
		public bool Matches(AddPostCommentCommandRequest request, PostCommentImage? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id.Id) &&
				   r.CommentId.EqualsOrdinalIgnoreCase(entity.Id.Id.CommentId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   request.Images.ContainsUrl(r.Url) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(UpdatePostCommentCommandRequest request, PostCommentImage? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.CommentId.EqualsOrdinalIgnoreCase(request.CommentId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeletePostCommentCommandRequest request, PostCommentImage? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.CommentId.EqualsOrdinalIgnoreCase(request.CommentId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(ICollection<PostCommentImageEventRequest> r)
	{
		public bool Matches(AddPostCommentCommandRequest request, ICollection<PostCommentImage> entities)
		{
			return r.MatchesCollectionAndEmpty(
				entities,
				response => new(new(new(response.Id), response.CommentId), response.ImageId),
				postCommentImage => postCommentImage.Id,
				(r, postCommentImage) => r.Matches(request, postCommentImage));
		}

		public bool Matches(UpdatePostCommentCommandRequest request, ICollection<PostCommentImage> entities)
		{
			return r.MatchesCollectionAndNotEmpty(
				entities,
				response => new(new(new(response.Id), response.CommentId), response.ImageId),
				postCommentImage => postCommentImage.Id,
				(r, postCommentImage) => r.Matches(request, postCommentImage));
		}

		public bool Matches(DeletePostCommentCommandRequest request, ICollection<PostCommentImage> entities)
		{
			return r.MatchesCollectionAndNotEmpty(
				entities,
				response => new(new(new(response.Id), response.CommentId), response.ImageId),
				postCommentImage => postCommentImage.Id,
				(r, postCommentImage) => r.Matches(request, postCommentImage));
		}
	}

	extension(UserEventRequest r)
	{
		public bool Matches(AddPostCommentCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(UpdatePostCommentCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeletePostCommentCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(GetAllPostCommentsQuery query)
	{
		public bool Matches(GetAllPostCommentsQueryRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostCommentsQuery, PostCommentsSortTerm, PostCommentsSortingQuery, GetAllPostCommentsQueryRequest>(request) &&
				   query.MatchesPaginatable<GetAllPostCommentsQuery, PostCommentsPaginationQuery, GetAllPostCommentsQueryRequest>(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostCommentsQueryRequest request)
		{
			return query.Filter.Id.Matches(request.Id) &&
				   query.Filter.UserName.Matches(request.UserName);
		}
	}

	extension(GetAllPostCommentsForUserQuery query)
	{
		public bool Matches(GetAllPostCommentsForUserQueryRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostCommentsForUserQuery, PostCommentsForUserSortTerm, PostCommentsForUserSortingQuery, GetAllPostCommentsForUserQueryRequest>(request) &&
				   query.MatchesPaginatable<GetAllPostCommentsForUserQuery, PostCommentsPaginationQuery, GetAllPostCommentsForUserQueryRequest>(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostCommentsForUserQueryRequest request)
		{
			return query.Filter.UserId.Matches(request.UserId);
		}
	}

	extension(GetPostCommentByIdQuery query)
	{
		public bool Matches(GetPostCommentByIdQueryRequest request)
		{
			return query.Id.Matches(request.Id, request.CommentId) &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddPostCommentCommand command)
	{
		public bool Matches(AddPostCommentCommandRequest request)
		{
			return command.Id.Matches(request.Id) &&
				   command.UserId.Matches(request.UserId) &&
				   command.Content == request.Content &&
				   command.Images == request.Images;
		}
	}

	extension(UpdatePostCommentCommand command)
	{
		public bool Matches(UpdatePostCommentCommandRequest request)
		{
			return command.Id.Matches(request.Id, request.CommentId) &&
				   command.UserId.Matches(request.UserId) &&
				   command.Content == request.Content;
		}
	}

	extension(DeletePostCommentCommand command)
	{
		public bool Matches(DeletePostCommentCommandRequest request)
		{
			return command.Id.Matches(request.Id, request.CommentId) &&
				   command.UserId.Matches(request.UserId);
		}
	}

	extension(AddPostCommentCommandResponse response)
	{
		public bool Matches(AddPostCommentCommandRequest request, PostComment postComment)
		{
			return response.Response.Matches(postComment.Id);
		}
	}

	extension(UpdatePostCommentCommandResponse response)
	{
		public bool Matches(UpdatePostCommentCommandRequest request, PostComment postComment)
		{
			return response.Response.Matches(postComment.Id);
		}
	}

	extension(GetPostCommentByIdQueryResponse response)
	{
		public bool Matches(GetPostCommentByIdQueryRequest request, PostComment postComment)
		{
			return response.Response.MatchesFull(request, postComment);
		}
	}

	extension(GetAllPostCommentsQueryResponse response)
	{
		public bool Matches(GetAllPostCommentsQueryRequest request, Post post, ICollection<PostComment> postComments)
		{
			return response.Response.MatchesWithoutUser(
				request,
				(response, comment) => response.MatchesWithoutPost(request, comment),
				comment => comment.MatchesFilter(request),
				post,
				postComments
			);
		}

		public bool Matches(GetAllPostCommentsQueryRequest request, Post post, ICollection<PostComment> postComments, ISortEnumTermTransformer<PostComment> termTransformer)
		{
			return response.Response.MatchesWithoutUser(
				request,
				(response, comment) => response.MatchesWithoutPost(request, comment),
				comment => comment.MatchesFilter(request),
				post,
				postComments,
				termTransformer
			);
		}
	}

	extension(GetAllPostCommentsForUserQueryResponse response)
	{
		public bool Matches(GetAllPostCommentsForUserQueryRequest request, User user, ICollection<PostComment> postComments)
		{
			return response.Response.MatchesWithoutPost(
				request,
				(response, comment) => response.MatchesWithoutUser(request, comment),
				comment => comment.MatchesFilter(request),
				user,
				postComments
			);
		}

		public bool Matches(GetAllPostCommentsForUserQueryRequest request, User user, ICollection<PostComment> postComments, ISortEnumTermTransformer<PostComment> termTransformer)
		{
			return response.Response.MatchesWithoutPost(
				request,
				(response, comment) => response.MatchesWithoutUser(request, comment),
				comment => comment.MatchesFilter(request),
				user,
				postComments,
				termTransformer
			);
		}
	}

	extension(PostComment postComment)
	{
		public bool Matches(AddPostCommentCommandRequest request)
		{
			return postComment.Id.Id.Matches(request.Id) &&
				   postComment.Id.CommentId.IsNotNullOrEmptyOrWhiteSpace() &&
				   postComment.UserId.Matches(request.UserId) &&
				   postComment.Content == request.Content &&
				   postComment.Summary.Matches(postComment.GetSummary(request)) &&
				   postComment.CreatedAtUtc != default &&
				   postComment.UpdatedAtUtc != default;
		}

		public bool Matches(UpdatePostCommentCommandRequest request)
		{
			return postComment.Id.Matches(request.Id, request.CommentId) &&
				   postComment.UserId.Matches(request.UserId) &&
				   postComment.Content == request.Content &&
				   postComment.Summary.Matches(postComment.GetSummary(request)) &&
				   postComment.CreatedAtUtc != default &&
				   postComment.UpdatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllPostCommentsQueryRequest request)
		{
			return postComment.Id.Id.Matches(request.Id) &&
				   postComment.User.MatchesFilter(request);
		}

		public bool MatchesFilter(GetAllPostCommentsForUserQueryRequest request)
		{
			return postComment.UserId.Matches(request.UserId);
		}
	}

	extension(PostCommentImage postCommentImage)
	{
		public bool Matches(AddPostCommentCommandRequest request)
		{
			return postCommentImage.Id.Id.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   postCommentImage.Id.Id.CommentId.IsNotNullOrEmptyOrWhiteSpace() &&
				   postCommentImage.Id.ImageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   request.Images.ContainsUrl(postCommentImage.Url) &&
				   postCommentImage.CreatedAtUtc != default;
		}
	}

	extension(ICollection<PostCommentImage> postCommentImages)
	{
		public bool Matches(AddPostCommentCommandRequest request)
		{
			return postCommentImages.AllAndEmpty(request.Images, postCommentImage => postCommentImage.Matches(request));
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(GetAllPostCommentsQueryRequest request)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
		}
	}

	extension(PostCommentIdCommandResponse response)
	{
		public bool Matches(PostCommentId id)
		{
			return id.Matches(response.Id, response.CommentId);
		}
	}

	extension(PostCommentQueryResponse? response)
	{
		public bool MatchesFull<TRequest>(TRequest request, PostComment? postComment)
		where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id, response.CommentId) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   postComment.Summary.Matches(response.Summary) &&
				   response.PostCommentImages.MatchesFull(postComment.PostCommentImages) &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(postComment.User) &&
				   response.Post.MatchesFull(request, postComment.Post);
		}

		public bool MatchesWithoutUser<TRequest>(TRequest request, PostComment? postComment)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id, response.CommentId) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   postComment.Summary.Matches(response.Summary) &&
				   response.PostCommentImages.MatchesFull(postComment.PostCommentImages) &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User == null &&
				   response.Post.MatchesFull(request, postComment.Post);
		}

		public bool MatchesWithoutPost<TRequest>(TRequest request, PostComment? postComment)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id, response.CommentId) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   postComment.Summary.Matches(response.Summary) &&
				   response.PostCommentImages.MatchesFull(postComment.PostCommentImages) &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(postComment.User) &&
				   response.Post == null;
		}
	}

	extension(PostCommentCollectionQueryResponse response)
	{
		public bool MatchesWithoutUser<TRequest>(TRequest request, Func<PostCommentQueryResponse, PostComment, bool> matches, Func<PostComment, bool> matchesFilter, Post post, ICollection<PostComment> postComments)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, postComments.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Post.MatchesFull(request, post) &&
				   response.PostComments.MatchesCollectionAndNotEmpty(
					   request,
					   postComments,
					   response => new(new(response.Id), response.CommentId),
					   postComment => postComment.Id,
					   matches,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutUser<TRequest>(TRequest request, Func<PostCommentQueryResponse, PostComment, bool> matches, Func<PostComment, bool> matchesFilter, Post post, ICollection<PostComment> postComments, ISortEnumTermTransformer<PostComment> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, postComments.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Post.MatchesFull(request, post) &&
				   response.PostComments.MatchesSortedCollection(
					   request,
					   postComments,
					   matches,
					   termTransformer,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutPost<TRequest>(TRequest request, Func<PostCommentQueryResponse, PostComment, bool> matches, Func<PostComment, bool> matchesFilter, User user, ICollection<PostComment> postComments)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, postComments.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostComments.MatchesCollectionAndNotEmpty(
					   request,
					   postComments,
					   response => new(new(response.Id), response.CommentId),
					   postComment => postComment.Id,
					   matches,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutPost<TRequest>(TRequest request, Func<PostCommentQueryResponse, PostComment, bool> matches, Func<PostComment, bool> matchesFilter, User user, ICollection<PostComment> postComments, ISortEnumTermTransformer<PostComment> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, postComments.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostComments.MatchesSortedCollection(
					   request,
					   postComments,
					   matches,
					   termTransformer,
					   matchesFilter
				   );
		}
	}
}
