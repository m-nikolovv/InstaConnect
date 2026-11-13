using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Collections;

internal class UserCollection : IUserCollection
{
	private readonly IUserFluentFactory _fluentFactory;
	private readonly IUserClaimCollection _claimCollection;
	private readonly IRefreshTokenCollection _refreshTokenCollection;
	private readonly IMongoDbCollectionHandler<User, UserId> _collectionHandler;
	private readonly IForgotPasswordTokenCollection _forgotPasswordTokenCollection;
	private readonly IEmailConfirmationTokenCollection _emailConfirmationTokenCollection;

	public UserCollection(
		IUserFluentFactory fluentFactory,
		IUserClaimCollection claimCollection,
		IRefreshTokenCollection refreshTokenCollection,
		IMongoDbCollectionHandler<User, UserId> collectionHandler,
		IForgotPasswordTokenCollection forgotPasswordTokenCollection,
		IEmailConfirmationTokenCollection emailConfirmationTokenCollection)
	{
		_fluentFactory = fluentFactory;
		_claimCollection = claimCollection;
		_collectionHandler = collectionHandler;
		_refreshTokenCollection = refreshTokenCollection;
		_forgotPasswordTokenCollection = forgotPasswordTokenCollection;
		_emailConfirmationTokenCollection = emailConfirmationTokenCollection;
	}

	public IUserFluent AggregateFluent()
	{
		var fluent = _collectionHandler.AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<User> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _claimCollection.DeleteByParentAsync(entity.Id.GetUserClaimByParentFilter(), cancellationToken);
		await _refreshTokenCollection.DeleteByParentAsync(entity.Id.GetRefreshTokenByParentFilter(), cancellationToken);
		await _forgotPasswordTokenCollection.DeleteByParentAsync(entity.Id.GetForgotPasswordTokenByParentFilter(), cancellationToken);
		await _emailConfirmationTokenCollection.DeleteByParentAsync(entity.Id.GetEmailConfirmationTokenByParentFilter(), cancellationToken);
		await _collectionHandler.RemoveAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
