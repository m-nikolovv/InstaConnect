using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Controllers.v1;

[ApiController]
[ApiVersion(EmailConfirmationTokenRoutes.Version1)]
[Route(EmailConfirmationTokenRoutes.Resource)]
[EnableRateLimiting(RateLimiterPolicies.Default)]
public class EmailConfirmationTokenController : ControllerBase
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;

	public EmailConfirmationTokenController(
		IApplicationMapper mapper,
		IApplicationSender sender)
	{
		_mapper = mapper;
		_sender = sender;
	}

	// POST: api/users/name/email-confirmation-tokens
	[HttpPost(EmailConfirmationTokenRoutes.Add)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult> AddAsync(
		AddEmailConfirmationTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<AddEmailConfirmationTokenCommandRequest>(request);
		await _sender.SendAsync(commandRequest, cancellationToken);

		return NoContent();
	}

	// PUT: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/email-confirmation-tokens/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg/verify
	[HttpPut(EmailConfirmationTokenRoutes.Verify)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult> VerifyAsync(
		VerifyEmailConfirmationTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<VerifyEmailConfirmationTokenCommandRequest>(request);
		await _sender.SendAsync(commandRequest, cancellationToken);

		return NoContent();
	}
}
