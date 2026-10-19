using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Requests.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Events.Features.PostCommentImages;
using InstaConnect.Posts.Events.Features.PostComments;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Extensions;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
	extension(PostCommentAddedEventRequest r)
	{
		public bool Matches(AddPostCommentApiRequest request, PostComment entity)
		{
			return r.PostComment.Matches(request, entity);
		}
	}

	extension(PostCommentUpdatedEventRequest r)
	{
		public bool Matches(UpdatePostCommentApiRequest request, PostComment entity)
		{
			return r.PostComment.Matches(request, entity);
		}
	}

	extension(PostCommentDeletedEventRequest r)
	{
		public bool Matches(DeletePostCommentApiRequest request, PostComment entity)
		{
			return r.PostComment.Matches(request, entity);
		}
	}

	extension(PostCommentEventRequest r)
	{
		public bool Matches(AddPostCommentApiRequest request, PostComment? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.CommentId.EqualsOrdinalIgnoreCase(entity.Id.CommentId) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.Content == request.Form.Content &&
				   r.Summary == entity.GetSummary(request) &&
				   r.User.Matches(request, entity.User) &&
				   r.PostCommentImages.Matches(request, entity.PostCommentImages) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(UpdatePostCommentApiRequest request, PostComment? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.CommentId.EqualsOrdinalIgnoreCase(request.CommentId) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.Content == request.Body.Content &&
				   r.Summary == entity.GetSummary(request) &&
				   r.User.Matches(request, entity.User) &&
				   r.PostCommentImages.Matches(request, entity.PostCommentImages) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeletePostCommentApiRequest request, PostComment? entity)
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
		public bool Matches(AddPostCommentApiRequest request, PostCommentImage? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id.Id) &&
				   r.CommentId.EqualsOrdinalIgnoreCase(entity.Id.Id.CommentId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   request.Form.Images.ContainsUrl(r.Url) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(UpdatePostCommentApiRequest request, PostCommentImage? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.CommentId.EqualsOrdinalIgnoreCase(request.CommentId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeletePostCommentApiRequest request, PostCommentImage? entity)
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
		public bool Matches(AddPostCommentApiRequest request, ICollection<PostCommentImage> entities)
		{
			return request.Form.Images.IsEmpty() ||
				   r.MatchesCollection(
					   entities,
					   response => new(new(new(response.Id), response.CommentId), response.ImageId),
					   postCommentImage => postCommentImage.Id,
					   (r, postCommentImage) => r.Matches(request, postCommentImage));
		}

		public bool Matches(UpdatePostCommentApiRequest request, ICollection<PostCommentImage> entities)
		{
			return r.MatchesCollection(
				entities,
				response => new(new(new(response.Id), response.CommentId), response.ImageId),
				postCommentImage => postCommentImage.Id,
				(r, postCommentImage) => r.Matches(request, postCommentImage));
		}

		public bool Matches(DeletePostCommentApiRequest request, ICollection<PostCommentImage> entities)
		{
			return r.MatchesCollection(
				entities,
				response => new(new(new(response.Id), response.CommentId), response.ImageId),
				postCommentImage => postCommentImage.Id,
				(r, postCommentImage) => r.Matches(request, postCommentImage));
		}
	}

	extension(UserEventRequest r)
	{
		public bool Matches(AddPostCommentApiRequest request, User? entity)
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

		public bool Matches(UpdatePostCommentApiRequest request, User? entity)
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

		public bool Matches(DeletePostCommentApiRequest request, User? entity)
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

	extension(GetAllPostCommentsQueryRequest query)
	{
		public bool Matches(GetAllPostCommentsApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostCommentsQueryRequest, PostCommentsSortTerm, GetAllPostCommentsApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostCommentsApiRequest request)
		{
			return query.Id == request.Id &&
				   query.UserName == request.UserName;
		}
	}

	extension(GetAllPostCommentsForUserQueryRequest query)
	{
		public bool Matches(GetAllPostCommentsForUserApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostCommentsForUserQueryRequest, PostCommentsForUserSortTerm, GetAllPostCommentsForUserApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostCommentsForUserApiRequest request)
		{
			return query.UserId == request.UserId;
		}
	}

	extension(GetPostCommentByIdQueryRequest query)
	{
		public bool Matches(GetPostCommentByIdApiRequest request)
		{
			return query.Id == request.Id &&
				   query.CommentId == request.CommentId &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddPostCommentCommandRequest command)
	{
		public bool Matches(AddPostCommentApiRequest request)
		{
			return command.Id == request.Id &&
				   command.Content == request.Form.Content &&
				   command.UserId == request.UserId &&
				   command.Images == request.Form.Images;
		}
	}

	extension(UpdatePostCommentCommandRequest command)
	{
		public bool Matches(UpdatePostCommentApiRequest request)
		{
			return command.Id == request.Id &&
				   command.CommentId == request.CommentId &&
				   command.Content == request.Body.Content &&
				   command.UserId == request.UserId;
		}
	}

	extension(DeletePostCommentCommandRequest command)
	{
		public bool Matches(DeletePostCommentApiRequest request)
		{
			return command.Id == request.Id &&
				   command.CommentId == request.CommentId &&
				   command.UserId == request.UserId;
		}
	}

	extension(AddPostCommentApiResponse response)
	{
		public bool Matches(
		AddPostCommentApiRequest request,
		PostComment postComment)
		{
			return response.Response.Matches(postComment.Id);
		}
	}

	extension(UpdatePostCommentApiResponse response)
	{
		public bool Matches(
		UpdatePostCommentApiRequest request,
		PostComment postComment)
		{
			return response.Response.Matches(postComment.Id);
		}
	}

	extension(GetPostCommentByIdApiResponse response)
	{
		public bool Matches(GetPostCommentByIdApiRequest request, PostComment postComment)
		{
			return response.Response.MatchesFull(request, postComment);
		}
	}

	extension(GetAllPostCommentsApiResponse response)
	{
		public bool Matches(
		GetAllPostCommentsApiRequest request,
		Post post,
		ICollection<PostComment> postComments)
		{
			return response.Response.MatchesWithoutUser(
					   request,
					   (response, postComment) => response.MatchesWithoutPost(request, postComment),
					   postComment => postComment.MatchesFilter(request),
					   post,
					   postComments);
		}

		public bool Matches(
			GetAllPostCommentsApiRequest request,
			Post post,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			return response.Response.MatchesWithoutUser(
					   request,
					   (response, postComment) => response.MatchesWithoutPost(request, postComment),
					   postComment => postComment.MatchesFilter(request),
					   post,
					   postComments,
					   termTransformer);
		}
	}

	extension(GetAllPostCommentsForUserApiResponse response)
	{
		public bool Matches(
		GetAllPostCommentsForUserApiRequest request,
		User user,
		ICollection<PostComment> postComments)
		{
			return response.Response.MatchesWithoutPost(
					   request,
					   (response, postComment) => response.MatchesWithoutUser(request, postComment),
					   postComment => postComment.MatchesFilter(request),
					   user,
					   postComments);
		}

		public bool Matches(
			GetAllPostCommentsForUserApiRequest request,
			User user,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			return response.Response.MatchesWithoutPost(
					   request,
					   (response, postComment) => response.MatchesWithoutUser(request, postComment),
					   postComment => postComment.MatchesFilter(request),
					   user,
					   postComments,
					   termTransformer);
		}
	}

	extension(PostComment postComment)
	{
		public bool Matches(AddPostCommentApiRequest request)
		{
			return postComment.Id.Id.Matches(request.Id) &&
				   postComment.Id.CommentId.IsNotNullOrEmptyOrWhiteSpace() &&
				   postComment.UserId.Matches(request.UserId) &&
				   postComment.Content == request.Form.Content &&
				   postComment.Summary.Matches(postComment.GetSummary(request)) &&
				   postComment.CreatedAtUtc != default &&
				   postComment.UpdatedAtUtc != default;
		}

		public bool Matches(UpdatePostCommentApiRequest request)
		{
			return postComment.Id.Matches(request.Id, request.CommentId) &&
				   postComment.UserId.Matches(request.UserId) &&
				   postComment.Content == request.Body.Content &&
				   postComment.Summary.Matches(postComment.GetSummary(request)) &&
				   postComment.CreatedAtUtc != default &&
				   postComment.UpdatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllPostCommentsApiRequest request)
		{
			return postComment.Id.Id.Matches(request.Id) &&
				   postComment.User.MatchesFilter(request);
		}

		public bool MatchesFilter(GetAllPostCommentsForUserApiRequest request)
		{
			return postComment.UserId.Matches(request.UserId);
		}
	}

	extension(PostCommentImage postCommentImage)
	{
		public bool Matches(AddPostCommentApiRequest request)
		{
			return postCommentImage.Id.Id.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   postCommentImage.Id.Id.CommentId.IsNotNullOrEmptyOrWhiteSpace() &&
				   postCommentImage.Id.ImageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   postCommentImage.Url.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   postCommentImage.CreatedAtUtc != default;
		}
	}

	extension(ICollection<PostCommentImage> postCommentImages)
	{
		public bool Matches(AddPostCommentApiRequest request)
		{
			return postCommentImages.AllAndNotEmpty(postCommentImage => postCommentImage.Matches(request));
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(GetAllPostCommentsApiRequest request)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
		}
	}

	extension(PostCommentIdApiResponse response)
	{
		public bool Matches(PostCommentId id)
		{
			return id.Matches(response.Id, response.CommentId);
		}
	}

	extension(PostCommentApiResponse? response)
	{
		public bool MatchesFull<TRequest>(TRequest request, PostComment? postComment)
		where TRequest : ICurrentUserableApiRequest
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
			where TRequest : ICurrentUserableApiRequest
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
			where TRequest : ICurrentUserableApiRequest
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

	extension(PostCommentCollectionApiResponse response)
	{
		public bool MatchesWithoutUser<TRequest>(
		TRequest request,
		Func<PostCommentApiResponse, PostComment, bool> matches,
		Func<PostComment, bool> matchesFilter,
		Post post,
		ICollection<PostComment> postComments)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, postComments.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Post.MatchesFull(request, post) &&
				   response.PostComments.MatchesCollection(request,
														postComments,
														response => new(new(response.Id), response.CommentId),
														postComment => postComment.Id,
														matches,
														matchesFilter);
		}

		public bool MatchesWithoutUser<TRequest>(
			TRequest request,
			Func<PostCommentApiResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			Post post,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, postComments.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Post.MatchesFull(request, post) &&
				   response.PostComments.MatchesSortedCollection(request,
															  postComments,
															  matches,
															  termTransformer,
															  matchesFilter);
		}

		public bool MatchesWithoutPost<TRequest>(
			TRequest request,
			Func<PostCommentApiResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			User user,
			ICollection<PostComment> postComments)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, postComments.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostComments.MatchesCollection(request,
														postComments,
														response => new(new(response.Id), response.CommentId),
														postComment => postComment.Id,
														matches,
														matchesFilter);
		}

		public bool MatchesWithoutPost<TRequest>(
			TRequest request,
			Func<PostCommentApiResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			User user,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, postComments.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostComments.MatchesSortedCollection(request,
															  postComments,
															  matches,
															  termTransformer,
															  matchesFilter);
		}
	}
}
