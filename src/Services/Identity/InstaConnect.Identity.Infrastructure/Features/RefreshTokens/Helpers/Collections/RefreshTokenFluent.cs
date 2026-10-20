using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Collections;

internal class RefreshTokenFluent : MongoDbFluent<RefreshToken>, IRefreshTokenFluent
{
	private readonly IRefreshTokenIncluderFactory _includerFactory;

	public RefreshTokenFluent(
		IAggregateFluent<RefreshToken> fluent,
		IRefreshTokenIncluderFactory includerFactory) : base(fluent)
	{
		_includerFactory = includerFactory;
	}

	public IRefreshTokenFluent ApplyIncludes(RefreshTokenInclude include)
	{
		ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IRefreshTokenFluent Match(RefreshTokenId filter)
	{
		Match(filter.GetFilter());

		return this;
	}
}
