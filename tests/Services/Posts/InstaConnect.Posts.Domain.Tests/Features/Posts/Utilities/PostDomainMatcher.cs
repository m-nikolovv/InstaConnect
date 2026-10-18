using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

public static class PostDomainMatcher
{
	extension(UpdatePostCommand command)
	{
		public Post IsPost()
		{
			return Matcher.Is<Post>(p => p.Matches(command));
		}

		public PostUpdatedEventRequest IsPostUpdatedEventRequest(Post post)
		{
			return Matcher.Is<PostUpdatedEventRequest>(p => p.Matches(command, post));
		}
	}

	extension(DeletePostCommand command)
	{
		public Post IsPost()
		{
			return Matcher.Is<Post>(p => p.Matches(command));
		}

		public PostDeletedEventRequest IsPostDeletedEventRequest(Post post)
		{
			return Matcher.Is<PostDeletedEventRequest>(p => p.Matches(command, post));
		}
	}

	extension(AddPostCommand command)
	{
		public Post IsPost()
		{
			return Matcher.Is<Post>(p => p.Matches(command));
		}

		public PostAddedEventRequest IsPostAddedEventRequest(Post post)
		{
			return Matcher.Is<PostAddedEventRequest>(p => p.Matches(command, post));
		}
		public ICollection<Url> IsImages()
		{
			return Matcher.Is<ICollection<Url>>(p => p.Matches(command));
		}

		public ICollection<PostImage> IsPostImages()
		{
			return Matcher.Is<ICollection<PostImage>>(p => p.Matches(command));
		}
	}

	extension(AnalyzePostByIdQuery query)
	{
		public PostResponse IsPostResponse(Post post)
		{
			return Matcher.Is<PostResponse>(p => p.MatchesFull(query, post));
		}
	}
}
