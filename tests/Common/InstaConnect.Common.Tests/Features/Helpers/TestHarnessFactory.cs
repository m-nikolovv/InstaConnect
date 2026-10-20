using InstaConnect.Common.Tests.Features.Extensions;

using MassTransit.Testing;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Tests.Features.Helpers;

public class TestHarnessFactory : ITestHarnessFactory
{
	private readonly string _connectionString;
	private readonly Assembly[] _currentAssemblies;

	public TestHarnessFactory(string connectionString, Assembly[] currentAssemblies)
	{
		_connectionString = connectionString;
		_currentAssemblies = currentAssemblies;
	}

	public ITestHarness Create()
	{
		return new ServiceCollection()
				.AddMassTransitTestEventClient(_connectionString, _currentAssemblies)
				.BuildServiceProvider(true)
				.GetTestHarness();
	}
}

