namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostSummarizer
{
	public Task<Summary> SummarizeAsync(Post post, CancellationToken cancellationToken);
}
