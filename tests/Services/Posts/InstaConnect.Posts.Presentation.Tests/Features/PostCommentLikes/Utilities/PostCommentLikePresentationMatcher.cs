using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikePresentationMatcher
{
	extension(GetAllPostCommentLikesApiRequest request)
	{
		public GetAllPostCommentLikesQueryRequest IsGetAllPostCommentLikesQueryRequest()
		{
			return Matcher.Is<GetAllPostCommentLikesQueryRequest>(p => p.Matches(request));
		}
	}

	extension(GetAllPostCommentLikesForUserApiRequest request)
	{
		public GetAllPostCommentLikesForUserQueryRequest IsGetAllPostCommentLikesForUserQueryRequest()
		{
			return Matcher.Is<GetAllPostCommentLikesForUserQueryRequest>(p => p.Matches(request));
		}
	}

	extension(GetPostCommentLikeByIdApiRequest request)
	{
		public GetPostCommentLikeByIdQueryRequest IsGetPostCommentLikeByIdQueryRequest()
		{
			return Matcher.Is<GetPostCommentLikeByIdQueryRequest>(p => p.Matches(request));
		}
	}

	extension(AddPostCommentLikeApiRequest request)
	{
		public AddPostCommentLikeCommandRequest IsAddPostCommentLikeCommandRequest()
		{
			return Matcher.Is<AddPostCommentLikeCommandRequest>(p => p.Matches(request));
		}
	}

	extension(DeletePostCommentLikeApiRequest request)
	{
		public DeletePostCommentLikeCommandRequest IsDeletePostCommentLikeCommandRequest()
		{
			return Matcher.Is<DeletePostCommentLikeCommandRequest>(p => p.Matches(request));
		}
	}
}
