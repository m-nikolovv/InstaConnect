using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;

namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Mappings;

public class ForgotPasswordTokenApplicationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<AddForgotPasswordTokenCommandRequest, AddForgotPasswordTokenCommand>()
			.ConstructUsing(src => new(
									   new(src.Name)));

		config.NewConfig<VerifyForgotPasswordTokenCommandRequest, VerifyForgotPasswordTokenCommand>()
			.ConstructUsing(src => new(
									   new(
										   new(src.Id),
										   src.Value),
									   src.Password,
									   src.ConfirmPassword));
	}
}
