using InstaConnect.Common.Events.Features.Events.Abstractions;

using MassTransit;
using MassTransit.Testing;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Tests.Features.Helpers;

public class EventClient : IEventClient
{
	private readonly ITestHarnessFactory _testHarnessFactory;

	private ITestHarness _testHarness;

	public EventClient(ITestHarnessFactory testHarnessFactory)
	{
		_testHarnessFactory = testHarnessFactory;
		_testHarness = testHarnessFactory.Create();
	}

	public async Task PublishAsync<TRequest>(TRequest message, CancellationToken cancellationToken)
		where TRequest : class, IEventRequest
	{
		var producerProvider = _testHarness.Scope.ServiceProvider.GetRequiredService<ITopicProducerProvider>();
		var producer = producerProvider.GetProducer<TRequest>(new Uri($"topic:{KebabCaseEndpointNameFormatter.Instance.Message<TRequest>()}"));

		await producer.Produce(message, cancellationToken);
		await _testHarness.InactivityTask;
	}

	public async Task<TRequest> PublishedAsync<TRequest>(CancellationToken cancellationToken)
		where TRequest : class, IEventRequest
	{
		return await _testHarness.Sent
				.SelectAsync<TRequest>(cancellationToken)
				.Select(a => a.Context.Message)
				.FirstAsync(cancellationToken);
	}

	public async Task<ICollection<TRequest>> PublishedRangeAsync<TRequest>(CancellationToken cancellationToken)
		where TRequest : class, IEventRequest
	{
		return await _testHarness.Sent
				.SelectAsync<TRequest>(cancellationToken)
				.Select(a => a.Context.Message)
				.ToListAsync(cancellationToken);
	}

	public async Task<TRequest> FaultedAsync<TRequest>(CancellationToken cancellationToken)
		where TRequest : class, IEventRequest
	{
		return await _testHarness
				.Consumed
				.SelectAsync<TRequest>(a => a.Exception != null, cancellationToken)
				.Select(a => a.Context.Message)
				.FirstAsync(cancellationToken);
	}

	public async Task<TRequest> ConsumedAsync<TRequest>(CancellationToken cancellationToken)
		where TRequest : class, IEventRequest
	{
		return await _testHarness.Consumed
				.SelectAsync<TRequest>(cancellationToken)
				.Select(a => a.Context.Message)
				.FirstAsync(cancellationToken);
	}

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		_testHarness = _testHarnessFactory.Create();

		await _testHarness.Start();
	}

	public async Task StopAsync(CancellationToken cancellationToken)
	{
		await _testHarness.Stop(cancellationToken);
	}
}

