using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Application.Features.UserClaims.Commands.Delete;

internal class DeleteUserClaimCommandHandler : ICommandHandler<DeleteUserClaimCommandRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IUserClaimCommandService _claimService;

	public DeleteUserClaimCommandHandler(
		IApplicationMapper mapper,
		IUserClaimCommandService claimService)
	{
		_mapper = mapper;
		_claimService = claimService;
	}

	public async Task Handle(
		DeleteUserClaimCommandRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<DeleteUserClaimCommand>(request);
		await _claimService.DeleteAsync(serviceRequest, cancellationToken);
	}
}
