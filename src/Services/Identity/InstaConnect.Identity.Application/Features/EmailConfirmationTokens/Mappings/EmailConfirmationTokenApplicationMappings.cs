using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;

namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Mappings;

public class EmailConfirmationTokenApplicationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{

		config.NewConfig<AddEmailConfirmationTokenCommandRequest, AddEmailConfirmationTokenCommand>()
			.ConstructUsing(src => new(
									   new(src.Name)));

		config.NewConfig<VerifyEmailConfirmationTokenCommandRequest, VerifyEmailConfirmationTokenCommand>()
			.ConstructUsing(src => new(
									   new(
										   new(src.Id),
										   src.Value)));
	}
}
