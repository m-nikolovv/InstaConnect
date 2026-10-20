using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;

namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;

internal class VerifyEmailConfirmationTokenCommandHandler : ICommandHandler<VerifyEmailConfirmationTokenCommandRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IEmailConfirmationTokenCommandService _emailConfirmationTokenService;

	public VerifyEmailConfirmationTokenCommandHandler(
		IApplicationMapper mapper,
		IEmailConfirmationTokenCommandService emailConfirmationTokenService)
	{
		_mapper = mapper;
		_emailConfirmationTokenService = emailConfirmationTokenService;
	}

	public async Task Handle(VerifyEmailConfirmationTokenCommandRequest request, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<VerifyEmailConfirmationTokenCommand>(request);
		await _emailConfirmationTokenService.VerifyAsync(serviceRequest, cancellationToken);
	}
}
