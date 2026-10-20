using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;

namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;

internal class AddForgotPasswordTokenCommandHandler : ICommandHandler<AddForgotPasswordTokenCommandRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IForgotPasswordTokenCommandService _forgotPasswordTokenService;

	public AddForgotPasswordTokenCommandHandler(
		IApplicationMapper mapper,
		IForgotPasswordTokenCommandService forgotPasswordTokenService)
	{
		_mapper = mapper;
		_forgotPasswordTokenService = forgotPasswordTokenService;
	}

	public async Task Handle(AddForgotPasswordTokenCommandRequest request, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<AddForgotPasswordTokenCommand>(request);
		await _forgotPasswordTokenService.AddAsync(serviceRequest, cancellationToken);
	}
}
