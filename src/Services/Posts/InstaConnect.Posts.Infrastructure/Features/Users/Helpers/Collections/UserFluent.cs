namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Collections;

internal class UserFluent : IUserFluent
{
	private readonly IUserIncluderFactory _includerFactory;
	private readonly IUserResponseFluentFactory _responseFluentFactory;
	private readonly IMongoDbFluentHandler<User, UserId> _fluentHandler;

	public UserFluent(
		IUserIncluderFactory includerFactory,
		IUserResponseFluentFactory responseFluentFactory,
		IMongoDbFluentHandler<User, UserId> fluentHandler)
	{
		_fluentHandler = fluentHandler;
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IUserFluent Include(UserInclude include)
	{
		_fluentHandler.Include(_includerFactory, include);

		return this;
	}

	public IUserFluent Match(UserId filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IUserFluent Match(Name filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IUserFluent Match(Email filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IUserResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser)
	{
		var projection = Builders<User>.Projection.Expression(
			 u => new UserResponse(
				 u.Id,
				 u.FirstName,
				 u.LastName,
				 u.Email,
				 u.Name,
				 u.ProfileImageUrl,
				 u.CreatedAtUtc,
				 u.UpdatedAtUtc));
		var fluent = _fluentHandler.Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IMongoDbFluent<User, UserId> Match(FilterDefinition<User> filterDefinition)
	{
		_fluentHandler.Match(filterDefinition);

		return this;
	}

	public async Task<User?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<long> GetCountAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetCountAsync(cancellationToken);
	}

	public async Task<ICollection<User>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}

	public async Task<bool> AnyAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.AnyAsync(cancellationToken);
	}

	public async Task<ICollection<UserId>> GetIdsAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetIdsAsync(cancellationToken);
	}
}
