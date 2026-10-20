using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;

namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;

internal class IssueRefreshTokenCommandHandler : ICommandHandler<IssueRefreshTokenCommandRequest, IssueRefreshTokenCommandResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IRefreshTokenCommandService _refreshTokenService;

	public IssueRefreshTokenCommandHandler(
		IApplicationMapper mapper,
		IRefreshTokenCommandService refreshTokenService)
	{
		_mapper = mapper;
		_refreshTokenService = refreshTokenService;
	}

	public async Task<IssueRefreshTokenCommandResponse> Handle(IssueRefreshTokenCommandRequest request, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<IssueRefreshTokenCommand>(request);
		var serviceResponse = await _refreshTokenService.IssueAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<IssueRefreshTokenCommandResponse>(serviceResponse);

		return response;
	}
}
