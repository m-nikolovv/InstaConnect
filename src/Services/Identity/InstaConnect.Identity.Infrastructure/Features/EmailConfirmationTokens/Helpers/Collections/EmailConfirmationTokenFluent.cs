using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Collections;

internal class EmailConfirmationTokenFluent : IEmailConfirmationTokenFluent
{
	private readonly IEmailConfirmationTokenIncluderFactory _includerFactory;
	private readonly IMongoDbFluentHandler<EmailConfirmationToken, EmailConfirmationTokenId> _fluentHandler;

	public EmailConfirmationTokenFluent(
		IEmailConfirmationTokenIncluderFactory includerFactory,
		IMongoDbFluentHandler<EmailConfirmationToken, EmailConfirmationTokenId> fluentHandler)
	{
		_fluentHandler = fluentHandler;
		_includerFactory = includerFactory;
	}

	public IEmailConfirmationTokenFluent Include(EmailConfirmationTokenInclude include)
	{
		_fluentHandler.Include(_includerFactory, include);

		return this;
	}

	public IEmailConfirmationTokenFluent Match(EmailConfirmationTokenId filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IEmailConfirmationTokenFluent Match(IEnumerable<EmailConfirmationTokenId> filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IMongoDbFluent<EmailConfirmationToken, EmailConfirmationTokenId> Match(FilterDefinition<EmailConfirmationToken> filterDefinition)
	{
		_fluentHandler.Match(filterDefinition);

		return this;
	}

	public async Task<EmailConfirmationToken?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<long> GetCountAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetCountAsync(cancellationToken);
	}

	public async Task<ICollection<EmailConfirmationToken>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}

	public async Task<bool> AnyAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.AnyAsync(cancellationToken);
	}

	public async Task<ICollection<EmailConfirmationTokenId>> GetIdsAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetIdsAsync(cancellationToken);
	}
}
