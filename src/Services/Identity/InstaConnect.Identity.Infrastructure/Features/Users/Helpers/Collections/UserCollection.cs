using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Collections;

internal class UserCollection : MongoDbCollection<User, UserId>, IUserCollection
{
	private readonly IUserFluentFactory _fluentFactory;
	private readonly IUserClaimCollection _claimCollection;
	private readonly IRefreshTokenCollection _refreshTokenCollection;
	private readonly IForgotPasswordTokenCollection _forgotPasswordTokenCollection;
	private readonly IEmailConfirmationTokenCollection _emailConfirmationTokenCollection;

	public UserCollection(
		ISessionHandler sessionHandler,
		IUserFluentFactory fluentFactory,
		IMongoCollection<User> collection,
		IUserClaimCollection claimCollection,
		IRefreshTokenCollection refreshTokenCollection,
		IForgotPasswordTokenCollection forgotPasswordTokenCollection,
		IEmailConfirmationTokenCollection emailConfirmationTokenCollection) : base(sessionHandler, collection)
	{
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

	public async Task UpdateAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await UpdateAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _claimCollection.CascadeDeleteAsync(entity.Id.GetUserClaimCascadeFilter(), cancellationToken);
		await _refreshTokenCollection.CascadeDeleteAsync(entity.Id.GetRefreshTokenCascadeFilter(), cancellationToken);
		await _forgotPasswordTokenCollection.CascadeDeleteAsync(entity.Id.GetForgotPasswordTokenCascadeFilter(), cancellationToken);
		await _emailConfirmationTokenCollection.CascadeDeleteAsync(entity.Id.GetEmailConfirmationTokenCascadeFilter(), cancellationToken);
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
