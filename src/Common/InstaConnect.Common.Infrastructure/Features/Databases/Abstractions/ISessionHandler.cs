namespace InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

public interface ISessionHandler
{
	public IClientSessionHandle? ClientSessionHandle { get; }

	public Task AbortAsync(CancellationToken cancellationToken);

	public Task BeginAsync(CancellationToken cancellationToken);

	public Task CommitAsync(CancellationToken cancellationToken);
}
