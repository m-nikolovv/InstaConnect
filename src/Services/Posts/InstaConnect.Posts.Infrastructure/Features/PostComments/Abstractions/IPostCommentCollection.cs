namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentCollection : IMongoDbCollection<PostComment>
{
	public IPostCommentFluent AggregateFluent();

	public Task UpdateAsync(
		PostComment entity,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		PostComment entity,
		CancellationToken cancellationToken);
}
