using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Application.Features.UserClaims.Commands.Add;

internal class AddUserClaimCommandHandler : ICommandHandler<AddUserClaimCommandRequest, AddUserClaimCommandResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IUserClaimCommandService _claimService;

	public AddUserClaimCommandHandler(
		IApplicationMapper mapper,
		IUserClaimCommandService claimService)
	{
		_mapper = mapper;
		_claimService = claimService;
	}

	public async Task<AddUserClaimCommandResponse> Handle(AddUserClaimCommandRequest request, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<AddUserClaimCommand>(request);
		var serviceResponse = await _claimService.AddAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<AddUserClaimCommandResponse>(serviceResponse);

		return response;
	}
}
