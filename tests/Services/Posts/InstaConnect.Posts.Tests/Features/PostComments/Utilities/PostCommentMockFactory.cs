using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Helpers;
using InstaConnect.Posts.Tests.Features.PostComments.Extensions;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentMockFactory
{
	public static IPostCommentIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new PostCommentIncludeBuilderFactory(new PostCommentIncludeDescriptorFactory());
	}

	public static IPostCommentSummarizer CreateSummarizer()
	{
		var summarizer = Mocker.Mock<IPostCommentSummarizer>();

		summarizer
			.SummarizeAsync(Matcher.Any<PostComment>(), Matcher.Any<CancellationToken>())
			.ReturnsTaskResponse<Summary, PostComment>(postComment => new(postComment.GetSummary()));

		return summarizer;
	}
}
