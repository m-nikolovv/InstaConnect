using InstaConnect.Common.Infrastructure.Features.Databases.Extensions;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

public class SessionHandler : ISessionHandler
{
	private readonly IMongoClient _mongoClient;

	private IClientSessionHandle? _clientSessionHandle;

	public SessionHandler(IMongoClient mongoClient)
	{
		_mongoClient = mongoClient;
	}

	public IClientSessionHandle? ClientSessionHandle => _clientSessionHandle;

	public async Task BeginAsync(CancellationToken cancellationToken)
	{
		_clientSessionHandle = await _mongoClient.StartSessionAsync(null, cancellationToken);
		_clientSessionHandle.StartTransaction();
	}

	public async Task CommitAsync(CancellationToken cancellationToken)
	{
		if (_clientSessionHandle.HasNoActiveTransaction())
		{
			return;
		}

		await _clientSessionHandle!.CommitTransactionAsync(cancellationToken);
	}

	public async Task AbortAsync(CancellationToken cancellationToken)
	{
		if (_clientSessionHandle.HasNoActiveTransaction())
		{
			return;
		}

		await _clientSessionHandle!.AbortTransactionAsync(cancellationToken);
	}
}
