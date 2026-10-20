using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Collections;

internal class ForgotPasswordTokenCollection : MongoDbCollection<ForgotPasswordToken>, IForgotPasswordTokenCollection
{
	private readonly IForgotPasswordTokenFluentFactory _fluentFactory;

	public ForgotPasswordTokenCollection(
		ISessionHandler sessionHandler,
		IForgotPasswordTokenFluentFactory fluentFactory,
		IMongoCollection<ForgotPasswordToken> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
	}

	public IForgotPasswordTokenFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task UpdateAsync(
		ForgotPasswordToken entity,
		CancellationToken cancellationToken)
	{
		await UpdateAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		ForgotPasswordToken entity,
		CancellationToken cancellationToken)
	{
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task DeleteRangeAsync(
		IEnumerable<ForgotPasswordToken> entities,
		CancellationToken cancellationToken)
	{
		await DeleteRangeAsync(entities.Select(p => p.Id).GetFilter(), cancellationToken);
	}
}
