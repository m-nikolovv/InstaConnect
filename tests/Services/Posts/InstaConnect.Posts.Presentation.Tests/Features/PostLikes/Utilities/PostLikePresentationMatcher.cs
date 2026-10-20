using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikePresentationMatcher
{
	extension(GetAllPostLikesApiRequest request)
	{
		public GetAllPostLikesQueryRequest IsGetAllPostLikesQueryRequest()
		{
			return Matcher.Is<GetAllPostLikesQueryRequest>(p => p.Matches(request));
		}
	}

	extension(GetAllPostLikesForUserApiRequest request)
	{
		public GetAllPostLikesForUserQueryRequest IsGetAllPostLikesForUserQueryRequest()
		{
			return Matcher.Is<GetAllPostLikesForUserQueryRequest>(p => p.Matches(request));
		}
	}

	extension(GetPostLikeByIdApiRequest request)
	{
		public GetPostLikeByIdQueryRequest IsGetPostLikeByIdQueryRequest()
		{
			return Matcher.Is<GetPostLikeByIdQueryRequest>(p => p.Matches(request));
		}
	}

	extension(AddPostLikeApiRequest request)
	{
		public AddPostLikeCommandRequest IsAddPostLikeCommandRequest()
		{
			return Matcher.Is<AddPostLikeCommandRequest>(p => p.Matches(request));
		}
	}

	extension(DeletePostLikeApiRequest request)
	{
		public DeletePostLikeCommandRequest IsDeletePostLikeCommandRequest()
		{
			return Matcher.Is<DeletePostLikeCommandRequest>(p => p.Matches(request));
		}
	}
}
