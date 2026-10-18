using InstaConnect.Common.Infrastructure.Features.Analyzers.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Analyzers;

internal class PostAnalyzer : IPostAnalyzer
{
	private readonly IAnalyzer _analyzer;
	private readonly IPostAnalyzeRequestFactory _requestFactory;
	private readonly IPostAnalyzeResponseFactory _responseFactory;

	public PostAnalyzer(
		IAnalyzer analyzer,
		IPostAnalyzeRequestFactory requestFactory,
		IPostAnalyzeResponseFactory responseFactory)
	{
		_analyzer = analyzer;
		_requestFactory = requestFactory;
		_responseFactory = responseFactory;
	}

	public async Task<PostAnalyzeResponse> AnalyzeAsync(PostResponse post, CancellationToken cancellationToken)
	{
		var serviceRequest = _requestFactory.Create(post);
		var summary = await _analyzer.AnalyzeAsync(serviceRequest, cancellationToken);

		return _responseFactory.Create(
			post.Id,
			post.UserId,
			post.Title,
			post.Content,
			post.User,
			post.PostImages,
			post.IsLikedByCurrentUser,
			summary,
			post.CreatedAtUtc,
			post.UpdatedAtUtc);
	}
}
