namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentCollection
{
	public IPostCommentFluent AggregateFluent();

	public Task AddAsync(
		PostComment entity,
		CancellationToken cancellationToken);

	public Task AddRangeAsync(
		IEnumerable<PostComment> entities,
		CancellationToken cancellationToken);

	public Task UpdateAsync(
		PostComment entity,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		PostComment entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<PostComment> filter,
		CancellationToken cancellationToken);
}
