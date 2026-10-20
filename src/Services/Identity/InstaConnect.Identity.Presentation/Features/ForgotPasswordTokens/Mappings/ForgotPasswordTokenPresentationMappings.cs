using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;

namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Mappings;

internal class ForgotPasswordTokenPresentationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<AddForgotPasswordTokenApiRequest, AddForgotPasswordTokenCommandRequest>()
			.ConstructUsing(src => new(src.Name));

		config.NewConfig<VerifyForgotPasswordTokenApiRequest, VerifyForgotPasswordTokenCommandRequest>()
			.ConstructUsing(src => new(
				src.Id,
				src.Value,
				src.Body.Password,
				src.Body.ConfirmPassword));
	}
}
