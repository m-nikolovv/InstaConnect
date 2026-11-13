using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Collections;

internal class RefreshTokenFluent : IRefreshTokenFluent
{
	private readonly IRefreshTokenIncluderFactory _includerFactory;
	private readonly IMongoDbFluentHandler<RefreshToken, RefreshTokenId> _fluentHandler;

	public RefreshTokenFluent(
		IRefreshTokenIncluderFactory includerFactory,
		IMongoDbFluentHandler<RefreshToken, RefreshTokenId> fluentHandler)
	{
		_fluentHandler = fluentHandler;
		_includerFactory = includerFactory;
	}

	public IRefreshTokenFluent ApplyIncludes(RefreshTokenInclude include)
	{
		_fluentHandler.ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IRefreshTokenFluent Match(RefreshTokenId filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IRefreshTokenFluent Match(IEnumerable<RefreshTokenId> filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IMongoDbFluent<RefreshToken, RefreshTokenId> Match(FilterDefinition<RefreshToken> filterDefinition)
	{
		_fluentHandler.Match(filterDefinition);

		return this;
	}

	public async Task<RefreshToken?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<long> GetCountAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetCountAsync(cancellationToken);
	}

	public async Task<ICollection<RefreshToken>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}

	public async Task<bool> AnyAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.AnyAsync(cancellationToken);
	}

	public async Task<ICollection<RefreshTokenId>> GetIdsAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetIdsAsync(cancellationToken);
	}
}
