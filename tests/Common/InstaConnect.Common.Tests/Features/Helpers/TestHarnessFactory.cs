using InstaConnect.Common.Infrastructure.Features.Events.Models;
using InstaConnect.Common.Tests.Features.Extensions;

using MassTransit;
using MassTransit.Testing;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Tests.Features.Helpers;

public class TestHarnessFactory : ITestHarnessFactory
{
	private readonly Assembly[] _assemblies;
	private readonly KafkaOptions _kafkaOptions;
	private readonly IConfiguration _configuration;
	private readonly Action<IRiderRegistrationContext, IKafkaFactoryConfigurator>? _mapEventHandlers;

	public TestHarnessFactory(
		Assembly[] assemblies,
		KafkaOptions kafkaOptions,
		IConfiguration configuration,
		Action<IRiderRegistrationContext, IKafkaFactoryConfigurator>? mapEventHandlers)
	{
		_assemblies = assemblies;
		_kafkaOptions = kafkaOptions;
		_configuration = configuration;
		_mapEventHandlers = mapEventHandlers;
	}

	public ITestHarness Create()
	{
		return new ServiceCollection()
				.AddSingleton(_configuration)
				.AddMassTransitTestEventClient(_kafkaOptions, _mapEventHandlers, _assemblies)
				.BuildServiceProvider(true)
				.GetTestHarness();
	}
}
