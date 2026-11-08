using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Collections;

internal class EmailConfirmationTokenCollection : MongoDbCollection<EmailConfirmationToken, EmailConfirmationTokenId>, IEmailConfirmationTokenCollection
{
	private readonly IEmailConfirmationTokenFluentFactory _fluentFactory;

	public EmailConfirmationTokenCollection(
		ISessionHandler sessionHandler,
		IEmailConfirmationTokenFluentFactory fluentFactory,
		IMongoCollection<EmailConfirmationToken> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
	}

	public IEmailConfirmationTokenFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task UpdateAsync(
		EmailConfirmationToken entity,
		CancellationToken cancellationToken)
	{
		await UpdateAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		EmailConfirmationToken entity,
		CancellationToken cancellationToken)
	{
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task DeleteRangeAsync(
		IEnumerable<EmailConfirmationToken> entities,
		CancellationToken cancellationToken)
	{
		if (entities.IsEmpty())
		{
			return;
		}

		await DeleteRangeAsync(entities.Select(p => p.Id).GetFilter(), cancellationToken);
	}

	public async Task CascadeDeleteAsync(
		FilterDefinition<EmailConfirmationToken> filter,
		CancellationToken cancellationToken)
	{
		await DeleteRangeAsync(filter, cancellationToken);
	}
}
