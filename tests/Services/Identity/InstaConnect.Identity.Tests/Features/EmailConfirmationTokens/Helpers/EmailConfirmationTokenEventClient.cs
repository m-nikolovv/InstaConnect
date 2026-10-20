using InstaConnect.Common.Tests.Features.Abstractions;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Helpers;

public class EmailConfirmationTokenEventClient : IEmailConfirmationTokenEventClient
{
	private readonly IEventClient _eventClient;

	public EmailConfirmationTokenEventClient(IEventClient eventClient)
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

	public async Task<EmailConfirmationTokenAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedAsync<EmailConfirmationTokenAddedEventRequest>(cancellationToken);
	}

	public async Task<ICollection<EmailConfirmationTokenAddedEventRequest>> PublishedAddedRangeAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedRangeAsync<EmailConfirmationTokenAddedEventRequest>(cancellationToken);
	}

	public async Task<ICollection<EmailConfirmationTokenDeletedEventRequest>> PublishedDeletedRangeAsync(CancellationToken cancellationToken)
	{
		return await _eventClient.PublishedRangeAsync<EmailConfirmationTokenDeletedEventRequest>(cancellationToken);
	}
}
