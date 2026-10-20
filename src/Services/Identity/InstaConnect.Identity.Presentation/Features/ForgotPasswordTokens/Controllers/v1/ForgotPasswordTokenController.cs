using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Controllers.v1;

[ApiController]
[ApiVersion(ForgotPasswordTokenRoutes.Version1)]
[Route(ForgotPasswordTokenRoutes.Resource)]
[EnableRateLimiting(RateLimiterPolicies.Default)]
public class ForgotPasswordTokenController : ControllerBase
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;

	public ForgotPasswordTokenController(
		IApplicationMapper mapper,
		IApplicationSender sender)
	{
		_mapper = mapper;
		_sender = sender;
	}

	// POST: api/users/user@example.com/forgot-password-tokens
	[HttpPost(ForgotPasswordTokenRoutes.Add)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult> AddAsync(
		AddForgotPasswordTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<AddForgotPasswordTokenCommandRequest>(request);
		await _sender.SendAsync(commandRequest, cancellationToken);

		return NoContent();
	}

	// PUT: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/forgot-password-tokens/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg/verify
	[HttpPut(ForgotPasswordTokenRoutes.Verify)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult> VerifyAsync(
		VerifyForgotPasswordTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<VerifyForgotPasswordTokenCommandRequest>(request);
		await _sender.SendAsync(commandRequest, cancellationToken);

		return NoContent();
	}
}
