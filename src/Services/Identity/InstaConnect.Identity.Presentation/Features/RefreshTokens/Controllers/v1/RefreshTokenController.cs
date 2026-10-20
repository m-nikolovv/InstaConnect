using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.DeleteCurrent;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Models.Responses;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Controllers.v1;

[ApiController]
[ApiVersion(RefreshTokenRoutes.Version1)]
[Route(RefreshTokenRoutes.Resource)]
[EnableRateLimiting(RateLimiterPolicies.Default)]
public class RefreshTokenController : ControllerBase
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;
	private readonly IRefreshTokenCookieStore _refreshTokenCookieStore;

	public RefreshTokenController(
		IApplicationMapper mapper,
		IApplicationSender sender,
		IRefreshTokenCookieStore refreshTokenCookieStore)
	{
		_mapper = mapper;
		_sender = sender;
		_refreshTokenCookieStore = refreshTokenCookieStore;
	}

	// POST: api/users/name/refresh-tokens/issue
	[HttpPost(RefreshTokenRoutes.Issue)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<IssueRefreshTokenApiResponse>> IssueAsync(
		IssueRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<IssueRefreshTokenCommandRequest>(request);
		var commandResponse = await _sender.SendAsync(commandRequest, cancellationToken);

		var cookie = _mapper.Map<SetRefreshTokenCookieApiRequest>(commandResponse.Response);
		_refreshTokenCookieStore.Set(cookie);

		var response = _mapper.Map<IssueRefreshTokenApiResponse>(commandResponse);

		return Ok(response);
	}

	// POST: api/users/current/refresh-tokens/current/rotate
	[HttpPost(RefreshTokenRoutes.CurrentRotate)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<RotateRefreshTokenApiResponse>> RotateAsync(
		RotateRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<RotateRefreshTokenCommandRequest>(request);
		var commandResponse = await _sender.SendAsync(commandRequest, cancellationToken);

		var cookie = _mapper.Map<SetRefreshTokenCookieApiRequest>(commandResponse.Response);
		_refreshTokenCookieStore.Set(cookie);

		var response = _mapper.Map<RotateRefreshTokenApiResponse>(commandResponse);

		return Ok(response);
	}


	// DELETE: api/users/current/refresh-tokens/current
	[HttpDelete(RefreshTokenRoutes.Current)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult> DeleteCurrentAsync(
		DeleteCurrentRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<DeleteCurrentRefreshTokenCommandRequest>(request);
		await _sender.SendAsync(commandRequest, cancellationToken);

		_refreshTokenCookieStore.Delete();

		return NoContent();
	}
}
