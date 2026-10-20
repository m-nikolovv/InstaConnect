using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostPresentationMatcher
{
	extension(GetAllPostsApiRequest request)
	{
		public GetAllPostsQueryRequest IsGetAllPostsQueryRequest()
		{
			return Matcher.Is<GetAllPostsQueryRequest>(p => p.Matches(request));
		}
	}

	extension(GetAllPostsForUserApiRequest request)
	{
		public GetAllPostsForUserQueryRequest IsGetAllPostsForUserQueryRequest()
		{
			return Matcher.Is<GetAllPostsForUserQueryRequest>(p => p.Matches(request));
		}
	}

	extension(GetPostByIdApiRequest request)
	{
		public GetPostByIdQueryRequest IsGetPostByIdQueryRequest()
		{
			return Matcher.Is<GetPostByIdQueryRequest>(p => p.Matches(request));
		}
	}

	extension(AddPostApiRequest request)
	{
		public AddPostCommandRequest IsAddPostCommandRequest()
		{
			return Matcher.Is<AddPostCommandRequest>(p => p.Matches(request));
		}
	}

	extension(UpdatePostApiRequest request)
	{
		public UpdatePostCommandRequest IsUpdatePostCommandRequest()
		{
			return Matcher.Is<UpdatePostCommandRequest>(p => p.Matches(request));
		}
	}

	extension(DeletePostApiRequest request)
	{
		public DeletePostCommandRequest IsDeletePostCommandRequest()
		{
			return Matcher.Is<DeletePostCommandRequest>(p => p.Matches(request));
		}
	}
}
