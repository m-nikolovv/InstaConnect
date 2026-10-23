using InstaConnect.Common.Application.Features.Databases.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

internal class UnitOfWork : IUnitOfWork
{
	private readonly ISessionHandler _sessionHandler;

	public UnitOfWork(ISessionHandler sessionHandler)
	{
		_sessionHandler = sessionHandler;
	}

	public async Task BeginAsync(CancellationToken cancellationToken)
	{
		await _sessionHandler.BeginAsync(cancellationToken);
	}

	public async Task CommitAsync(CancellationToken cancellationToken)
	{
		await _sessionHandler.CommitAsync(cancellationToken);
	}

	public async Task AbortAsync(CancellationToken cancellationToken)
	{
		await _sessionHandler.AbortAsync(cancellationToken);
	}
}
