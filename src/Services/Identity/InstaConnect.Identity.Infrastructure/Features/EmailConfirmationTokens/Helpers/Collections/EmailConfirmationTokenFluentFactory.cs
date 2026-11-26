using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Collections;

internal class EmailConfirmationTokenFluentFactory : IEmailConfirmationTokenFluentFactory
{
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;
	private readonly IEmailConfirmationTokenIncluderFactory _includerFactory;

	public EmailConfirmationTokenFluentFactory(
		IMongoDbFluentHandlerFactory fluentHandlerFactory,
		IEmailConfirmationTokenIncluderFactory includerFactory)
	{
		_includerFactory = includerFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
	}

	public IEmailConfirmationTokenFluent Create(IAggregateFluent<EmailConfirmationToken> fluent)
	{
		return new EmailConfirmationTokenFluent(_includerFactory, _fluentHandlerFactory.Create<EmailConfirmationToken, EmailConfirmationTokenId>(fluent));
	}
}
