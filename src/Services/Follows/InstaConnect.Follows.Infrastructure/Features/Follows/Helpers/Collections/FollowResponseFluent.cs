namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowResponseFluent : IFollowResponseFluent
{
	private readonly IMongoDbResponseFluentHandler<FollowResponse> _fluentHandler;

	public FollowResponseFluent(IMongoDbResponseFluentHandler<FollowResponse> fluentHandler)
	{
		_fluentHandler = fluentHandler;
	}

	public async Task<FollowResponse?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<FollowResponse>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}
}
