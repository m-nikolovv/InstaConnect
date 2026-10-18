using Microsoft.Extensions.AI;

namespace InstaConnect.Common.Infrastructure.Features.Analyzers.Abstractions;

public interface IAnalyzer
{
	public Task<string> AnalyzeAsync(ChatMessage message, CancellationToken cancellationToken);
}
