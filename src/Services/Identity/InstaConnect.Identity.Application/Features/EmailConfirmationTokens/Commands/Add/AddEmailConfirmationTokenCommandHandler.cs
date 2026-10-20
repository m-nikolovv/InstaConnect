using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;

namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;

internal class AddEmailConfirmationTokenCommandHandler : ICommandHandler<AddEmailConfirmationTokenCommandRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IEmailConfirmationTokenCommandService _emailConfirmationTokenService;

	public AddEmailConfirmationTokenCommandHandler(
		IApplicationMapper mapper,
		IEmailConfirmationTokenCommandService emailConfirmationTokenService)
	{
		_mapper = mapper;
		_emailConfirmationTokenService = emailConfirmationTokenService;
	}

	public async Task Handle(AddEmailConfirmationTokenCommandRequest request, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<AddEmailConfirmationTokenCommand>(request);
		await _emailConfirmationTokenService.AddAsync(serviceRequest, cancellationToken);
	}
}
