using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;

namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.DeleteCurrent;

internal class DeleteCurrentRefreshTokenCommandHandler : ICommandHandler<DeleteCurrentRefreshTokenCommandRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IRefreshTokenCommandService _refreshTokenService;

	public DeleteCurrentRefreshTokenCommandHandler(
		IApplicationMapper mapper,
		IRefreshTokenCommandService refreshTokenService)
	{
		_mapper = mapper;
		_refreshTokenService = refreshTokenService;
	}

	public async Task Handle(
		DeleteCurrentRefreshTokenCommandRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<DeleteRefreshTokenCommand>(request);
		await _refreshTokenService.DeleteAsync(serviceRequest, cancellationToken);
	}
}
