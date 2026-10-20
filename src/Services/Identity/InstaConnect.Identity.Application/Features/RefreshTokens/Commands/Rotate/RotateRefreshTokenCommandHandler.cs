using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;

namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;

internal class RotateRefreshTokenCommandHandler : ICommandHandler<RotateRefreshTokenCommandRequest, RotateRefreshTokenCommandResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IRefreshTokenCommandService _refreshTokenService;

	public RotateRefreshTokenCommandHandler(
		IApplicationMapper mapper,
		IRefreshTokenCommandService refreshTokenService)
	{
		_mapper = mapper;
		_refreshTokenService = refreshTokenService;
	}

	public async Task<RotateRefreshTokenCommandResponse> Handle(RotateRefreshTokenCommandRequest request, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<RotateRefreshTokenCommand>(request);
		var serviceResponse = await _refreshTokenService.RotateAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<RotateRefreshTokenCommandResponse>(serviceResponse);

		return response;
	}
}
