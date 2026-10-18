namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostApplicationMatcher
{
	extension(GetAllPostsQueryRequest request)
	{
		public GetAllPostsQuery IsGetAllPostsQuery()
		{
			return Matcher.Is<GetAllPostsQuery>(p => p.Matches(request));
		}
	}

	extension(GetAllPostsForUserQueryRequest request)
	{
		public GetAllPostsForUserQuery IsGetAllPostsForUserQuery()
		{
			return Matcher.Is<GetAllPostsForUserQuery>(p => p.Matches(request));
		}
	}

	extension(GetPostByIdQueryRequest request)
	{
		public GetPostByIdQuery IsGetPostByIdQuery()
		{
			return Matcher.Is<GetPostByIdQuery>(p => p.Matches(request));
		}
	}

	extension(AddPostCommandRequest request)
	{
		public AddPostCommand IsAddPostCommand()
		{
			return Matcher.Is<AddPostCommand>(p => p.Matches(request));
		}
	}

	extension(UpdatePostCommandRequest request)
	{
		public UpdatePostCommand IsUpdatePostCommand()
		{
			return Matcher.Is<UpdatePostCommand>(p => p.Matches(request));
		}
	}

	extension(DeletePostCommandRequest request)
	{
		public DeletePostCommand IsDeletePostCommand()
		{
			return Matcher.Is<DeletePostCommand>(p => p.Matches(request));
		}
	}
}
