namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostAnalyzer
{
	public Task<PostAnalyzeResponse> AnalyzeAsync(PostResponse post, CancellationToken cancellationToken);
}
