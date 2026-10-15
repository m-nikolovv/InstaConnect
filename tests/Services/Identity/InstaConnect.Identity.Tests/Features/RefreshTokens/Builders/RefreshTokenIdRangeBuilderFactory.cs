using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;

public class RefreshTokenIdRangeBuilderFactory
{
	private readonly RefreshTokenIdBuilderFactory _idBuilderFactory;

	public RefreshTokenIdRangeBuilderFactory()
	{
		_idBuilderFactory = new();
	}

	public RefreshTokenIdRangeBuilder Create(ICollection<RefreshTokenId> ids)
	{
		return new([.. ids.Select(_idBuilderFactory.Create)]);
	}
}
