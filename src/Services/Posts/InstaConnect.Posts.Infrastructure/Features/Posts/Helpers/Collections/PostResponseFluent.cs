namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostResponseFluent : IPostResponseFluent
{
	private readonly IMongoDbResponseFluentHandler<PostResponse> _fluentHandler;

	public PostResponseFluent(IMongoDbResponseFluentHandler<PostResponse> fluentHandler)
	{
		_fluentHandler = fluentHandler;
	}

	public async Task<PostResponse?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<PostResponse>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}
}
