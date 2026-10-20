namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentCollection : MongoDbCollection<PostComment>, IPostCommentCollection
{
	private readonly IPostCommentFluentFactory _fluentFactory;

	public PostCommentCollection(
		ISessionHandler sessionHandler,
		IPostCommentFluentFactory fluentFactory,
		IMongoCollection<PostComment> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
	}

	public IPostCommentFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task UpdateAsync(
		PostComment entity,
		CancellationToken cancellationToken)
	{
		await UpdateAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		PostComment entity,
		CancellationToken cancellationToken)
	{
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
