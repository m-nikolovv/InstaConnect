namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

public interface IPostCommentSummarizer
{
	public Task<Summary> SummarizeAsync(PostComment postComment, CancellationToken cancellationToken);
}
