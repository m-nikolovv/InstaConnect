using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;

namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Mappings;

internal class EmailConfirmationTokenPresentationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<AddEmailConfirmationTokenApiRequest, AddEmailConfirmationTokenCommandRequest>()
			.ConstructUsing(src => new(src.Name));

		config.NewConfig<VerifyEmailConfirmationTokenApiRequest, VerifyEmailConfirmationTokenCommandRequest>()
			.ConstructUsing(src => new(
				src.Id,
				src.Value));
	}
}
