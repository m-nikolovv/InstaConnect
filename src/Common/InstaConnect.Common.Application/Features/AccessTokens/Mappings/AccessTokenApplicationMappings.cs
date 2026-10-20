using InstaConnect.Common.Application.Features.AccessTokens.Models;
using InstaConnect.Common.Domain.Features.AccessTokens.Models;

namespace InstaConnect.Common.Application.Features.AccessTokens.Mappings;

public class AccessTokenApplicationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<AccessToken, AccessTokenCommandResponse>()
			.ConstructUsing(src => new(
				src.Value,
				src.ExpiresAtUtc));
	}
}
