using InstaConnect.Common.Tests.Features.Abstractions;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Abstractions;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Helpers;

public class ForgotPasswordTokenEventClient : IForgotPasswordTokenEventClient
{
	private readonly IEventClient _eventClient;

	public ForgotPasswordTokenEventClient(IEventClient eventClient)
	{
		_eventClient = eventClient;
	}

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		await _eventClient.StartAsync(cancellationToken);
	}

	public async Task StopAsync(CancellationToken cancellationToken)
	{
		await _eventClient.StopAsync(cancellationToken);
	}

	public async Task<ICollection<ForgotPasswordTokenAddedEventRequest>> PublishedAddedRangeAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedRangeAsync<ForgotPasswordTokenAddedEventRequest>(cancellationToken);
	}

	public async Task<ICollection<ForgotPasswordTokenDeletedEventRequest>> PublishedDeletedRangeAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedRangeAsync<ForgotPasswordTokenDeletedEventRequest>(cancellationToken);
	}
}
