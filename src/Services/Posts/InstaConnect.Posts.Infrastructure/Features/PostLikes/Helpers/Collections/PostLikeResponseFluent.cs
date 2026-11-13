namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeResponseFluent : IPostLikeResponseFluent
{
	private readonly IMongoDbResponseFluentHandler<PostLikeResponse> _fluentHandler;

	public PostLikeResponseFluent(IMongoDbResponseFluentHandler<PostLikeResponse> fluentHandler)
	{
		_fluentHandler = fluentHandler;
	}

	public async Task<PostLikeResponse?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<PostLikeResponse>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}
}
