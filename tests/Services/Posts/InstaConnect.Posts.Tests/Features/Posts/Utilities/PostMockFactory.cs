using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Helpers;
using InstaConnect.Posts.Tests.Features.Posts.Extensions;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostMockFactory
{
	public static IPostIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new PostIncludeBuilderFactory(new PostIncludeDescriptorFactory());
	}

	public static IPostSummarizer CreateSummarizer()
	{
		var summarizer = Mocker.Mock<IPostSummarizer>();

		summarizer
			.SummarizeAsync(Matcher.Any<Post>(), Matcher.Any<CancellationToken>())
			.ReturnsTaskResponse<Summary, Post>(post => new(post.GetSummary()));

		return summarizer;
	}
}
