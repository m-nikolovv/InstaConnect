namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Collections;

internal class UserResponseFluent : IUserResponseFluent
{
	private readonly IMongoDbResponseFluentHandler<UserResponse> _fluentHandler;

	public UserResponseFluent(IMongoDbResponseFluentHandler<UserResponse> fluentHandler)
	{
		_fluentHandler = fluentHandler;
	}

	public async Task<UserResponse?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<UserResponse>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}
}
