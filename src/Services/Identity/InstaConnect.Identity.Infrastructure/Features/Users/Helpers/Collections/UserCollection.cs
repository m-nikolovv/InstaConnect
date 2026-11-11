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
		await _claimCollection.CascadeAddAsync(entity.Id.GetUserClaimCascadeFilter(), cancellationToken);
		await _refreshTokenCollection.CascadeAddAsync(entity.Id.GetRefreshTokenCascadeFilter(), cancellationToken);
		await _forgotPasswordTokenCollection.CascadeAddAsync(entity.Id.GetForgotPasswordTokenCascadeFilter(), cancellationToken);
		await _emailConfirmationTokenCollection.CascadeAddAsync(entity.Id.GetEmailConfirmationTokenCascadeFilter(), cancellationToken);
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
		await _claimCollection.CascadeUpdateAsync(entity.Id.GetUserClaimCascadeFilter(), cancellationToken);
		await _refreshTokenCollection.CascadeUpdateAsync(entity.Id.GetRefreshTokenCascadeFilter(), cancellationToken);
		await _forgotPasswordTokenCollection.CascadeUpdateAsync(entity.Id.GetForgotPasswordTokenCascadeFilter(), cancellationToken);
		await _emailConfirmationTokenCollection.CascadeUpdateAsync(entity.Id.GetEmailConfirmationTokenCascadeFilter(), cancellationToken);
		await ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _claimCollection.CascadeDeleteAsync(entity.Id.GetUserClaimCascadeFilter(), cancellationToken);
		await _refreshTokenCollection.CascadeDeleteAsync(entity.Id.GetRefreshTokenCascadeFilter(), cancellationToken);
		await _forgotPasswordTokenCollection.CascadeDeleteAsync(entity.Id.GetForgotPasswordTokenCascadeFilter(), cancellationToken);
		await _emailConfirmationTokenCollection.CascadeDeleteAsync(entity.Id.GetEmailConfirmationTokenCascadeFilter(), cancellationToken);
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}
}
