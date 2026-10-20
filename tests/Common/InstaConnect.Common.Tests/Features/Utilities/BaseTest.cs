using FluentValidation;

using Xunit;

namespace InstaConnect.Common.Tests.Features.Utilities;

public abstract class BaseTest : IAsyncLifetime
{
	protected CancellationToken CancellationToken { get; }

	protected BaseTest()
	{
		ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;

		CancellationToken = MockFactory.CreateCancellationToken();
	}

	public virtual async Task InitializeAsync()
	{
		await OnInitializeAsync();
	}

	protected virtual Task OnInitializeAsync()
	{
		return Task.CompletedTask;
	}

	public virtual Task DisposeAsync()
	{
		return Task.CompletedTask;
	}
}
