using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Collections;

internal class EmailConfirmationTokenFluent : MongoDbFluent<EmailConfirmationToken>, IEmailConfirmationTokenFluent
{
	private readonly IEmailConfirmationTokenIncluderFactory _includerFactory;

	public EmailConfirmationTokenFluent(
		IAggregateFluent<EmailConfirmationToken> fluent,
		IEmailConfirmationTokenIncluderFactory includerFactory) : base(fluent)
	{
		_includerFactory = includerFactory;
	}

	public IEmailConfirmationTokenFluent ApplyIncludes(EmailConfirmationTokenInclude include)
	{
		ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IEmailConfirmationTokenFluent Match(EmailConfirmationTokenId filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IEmailConfirmationTokenFluent Match(IEnumerable<EmailConfirmationTokenId> filter)
	{
		Match(filter.GetFilter());

		return this;
	}
}
