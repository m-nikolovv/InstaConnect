using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Collections;

internal class UserCollection : MongoDbCollection<User, UserId>, IUserCollection
{
	private readonly IUserCacheHandler _cacheHandler;
	private readonly IUserFluentFactory _fluentFactory;
	private readonly IUserClaimCollection _claimCollection;
	private readonly IRefreshTokenCollection _refreshTokenCollection;
	private readonly IForgotPasswordTokenCollection _forgotPasswordTokenCollection;
	private readonly IEmailConfirmationTokenCollection _emailConfirmationTokenCollection;

	public UserCollection(
		ISessionHandler sessionHandler,
		IUserCacheHandler cacheHandler,
		IUserFluentFactory fluentFactory,
		IMongoCollection<User> collection,
		IUserClaimCollection claimCollection,
		IRefreshTokenCollection refreshTokenCollection,
		IForgotPasswordTokenCollection forgotPasswordTokenCollection,
		IEmailConfirmationTokenCollection emailConfirmationTokenCollection) : base(sessionHandler, collection)
	{
		_cacheHandler = cacheHandler;
		_fluentFactory = fluentFactory;
		_claimCollection = claimCollection;
		_refreshTokenCollection = refreshTokenCollection;
		_forgotPasswordTokenCollection = forgotPasswordTokenCollection;
		_emailConfirmationTokenCollection = emailConfirmationTokenCollection;
	}

	public IUserFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _claimCollection.AddByParentAsync(entity.Id.GetUserClaimByParentFilter(), cancellationToken);
		await _refreshTokenCollection.AddByParentAsync(entity.Id.GetRefreshTokenByParentFilter(), cancellationToken);
		await _forgotPasswordTokenCollection.AddByParentAsync(entity.Id.GetForgotPasswordTokenByParentFilter(), cancellationToken);
		await _emailConfirmationTokenCollection.AddByParentAsync(entity.Id.GetEmailConfirmationTokenByParentFilter(), cancellationToken);
		await InsertAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task AddRangeAsync(
		IEnumerable<User> entities,
		CancellationToken cancellationToken)
	{
		await InsertRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task UpdateAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _claimCollection.UpdateByParentAsync(entity.Id.GetUserClaimByParentFilter(), cancellationToken);
		await _refreshTokenCollection.UpdateByParentAsync(entity.Id.GetRefreshTokenByParentFilter(), cancellationToken);
		await _forgotPasswordTokenCollection.UpdateByParentAsync(entity.Id.GetForgotPasswordTokenByParentFilter(), cancellationToken);
		await _emailConfirmationTokenCollection.UpdateByParentAsync(entity.Id.GetEmailConfirmationTokenByParentFilter(), cancellationToken);
		await ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _claimCollection.DeleteByParentAsync(entity.Id.GetUserClaimByParentFilter(), cancellationToken);
		await _refreshTokenCollection.DeleteByParentAsync(entity.Id.GetRefreshTokenByParentFilter(), cancellationToken);
		await _forgotPasswordTokenCollection.DeleteByParentAsync(entity.Id.GetForgotPasswordTokenByParentFilter(), cancellationToken);
		await _emailConfirmationTokenCollection.DeleteByParentAsync(entity.Id.GetEmailConfirmationTokenByParentFilter(), cancellationToken);
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}
}
