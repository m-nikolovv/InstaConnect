namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Collections;

internal class UserClaimResponseFluent : IUserClaimResponseFluent
{
	private readonly IMongoDbResponseFluentHandler<UserClaimResponse> _fluentHandler;

	public UserClaimResponseFluent(IMongoDbResponseFluentHandler<UserClaimResponse> fluentHandler)
	{
		_fluentHandler = fluentHandler;
	}

	public async Task<UserClaimResponse?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<UserClaimResponse>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}
}
