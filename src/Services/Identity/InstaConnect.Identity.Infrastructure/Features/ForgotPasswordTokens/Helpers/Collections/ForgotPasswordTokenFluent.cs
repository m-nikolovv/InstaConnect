using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Collections;

internal class ForgotPasswordTokenFluent : IForgotPasswordTokenFluent
{
	private readonly IForgotPasswordTokenIncluderFactory _includerFactory;
	private readonly IMongoDbFluentHandler<ForgotPasswordToken, ForgotPasswordTokenId> _fluentHandler;

	public ForgotPasswordTokenFluent(
		IForgotPasswordTokenIncluderFactory includerFactory,
		IMongoDbFluentHandler<ForgotPasswordToken, ForgotPasswordTokenId> fluentHandler)
	{
		_fluentHandler = fluentHandler;
		_includerFactory = includerFactory;
	}

	public IForgotPasswordTokenFluent ApplyIncludes(ForgotPasswordTokenInclude include)
	{
		_fluentHandler.ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IForgotPasswordTokenFluent Match(ForgotPasswordTokenId filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IForgotPasswordTokenFluent Match(IEnumerable<ForgotPasswordTokenId> filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IMongoDbFluent<ForgotPasswordToken, ForgotPasswordTokenId> Match(FilterDefinition<ForgotPasswordToken> filterDefinition)
	{
		_fluentHandler.Match(filterDefinition);

		return this;
	}

	public async Task<ForgotPasswordToken?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<long> GetCountAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetCountAsync(cancellationToken);
	}

	public async Task<ICollection<ForgotPasswordToken>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}

	public async Task<bool> AnyAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.AnyAsync(cancellationToken);
	}

	public async Task<ICollection<ForgotPasswordTokenId>> GetIdsAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetIdsAsync(cancellationToken);
	}
}
