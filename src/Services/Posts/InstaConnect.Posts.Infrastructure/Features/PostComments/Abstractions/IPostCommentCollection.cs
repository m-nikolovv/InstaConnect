namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentCollection : IMongoDbCollection<PostComment>
{
	public IPostCommentFluent AggregateFluent();

	internal Task AddByParentAsync(
		FilterDefinition<PostComment> filter,
		CancellationToken cancellationToken);

	public Task UpdateAsync(
		PostComment entity,
		CancellationToken cancellationToken);

	internal Task UpdateByParentAsync(
		FilterDefinition<PostComment> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		PostComment entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<PostComment> filter,
		CancellationToken cancellationToken);
}
