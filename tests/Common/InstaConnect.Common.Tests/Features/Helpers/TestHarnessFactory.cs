using InstaConnect.Common.Infrastructure.Features.Events.Models;
using InstaConnect.Common.Tests.Features.Extensions;

using MassTransit;
using MassTransit.Testing;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Tests.Features.Helpers;

public class TestHarnessFactory : ITestHarnessFactory
{
	private readonly KafkaOptions _kafkaOptions;
	private readonly Action<IRiderRegistrationContext, IKafkaFactoryConfigurator, IDictionary<string, KafkaConsumerOptions>>? _mapEventHandlers;
	private readonly Assembly[] _assemblies;

	public TestHarnessFactory(
		KafkaOptions kafkaOptions,
		Action<IRiderRegistrationContext, IKafkaFactoryConfigurator, IDictionary<string, KafkaConsumerOptions>>? mapEventHandlers,
		Assembly[] assemblies)
	{
		_kafkaOptions = kafkaOptions;
		_mapEventHandlers = mapEventHandlers;
		_assemblies = assemblies;
	}

	public ITestHarness Create()
	{
		return new ServiceCollection()
				.AddMassTransitTestEventClient(_kafkaOptions, _mapEventHandlers, _assemblies)
				.BuildServiceProvider(true)
				.GetTestHarness();
	}
}

