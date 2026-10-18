using InstaConnect.Common.Infrastructure.Features.Analyzers.Abstractions;

using Microsoft.Extensions.AI;

namespace InstaConnect.Common.Infrastructure.Features.Analyzers.Helpers;

internal class Analyzer : IAnalyzer
{
	private readonly IChatClient _chatClient;

	public Analyzer(IChatClient chatClient)
	{
		_chatClient = chatClient;
	}

	public async Task<string> AnalyzeAsync(ChatMessage message, CancellationToken cancellationToken)
	{
		var response = await _chatClient.GetResponseAsync(message, cancellationToken: cancellationToken);

		return response.Text;
	}
}
