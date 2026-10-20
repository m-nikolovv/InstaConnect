using InstaConnect.Common.Application.Features.Databases.Abstractions;

using MassTransit.MongoDbIntegration;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

internal class UnitOfWork : IUnitOfWork
{
	private readonly ISessionHandler _sessionHandler;
	private readonly MongoDbContext _mongoDbContext;

	public UnitOfWork(ISessionHandler sessionHandler, MongoDbContext mongoDbContext)
	{
		_sessionHandler = sessionHandler;
		_mongoDbContext = mongoDbContext;
	}

	public async Task BeginAsync(CancellationToken cancellationToken)
	{
		await _sessionHandler.BeginAsync(cancellationToken);
		await _mongoDbContext.BeginTransaction(cancellationToken);
	}

	public async Task CommitAsync(CancellationToken cancellationToken)
	{
		await _sessionHandler.CommitAsync(cancellationToken);
		await _mongoDbContext.CommitTransaction(cancellationToken);
	}

	public async Task AbortAsync(CancellationToken cancellationToken)
	{
		await _sessionHandler.AbortAsync(cancellationToken);
		await _mongoDbContext.AbortTransaction(cancellationToken);
	}

}
