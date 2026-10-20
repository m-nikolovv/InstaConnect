using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;

using Microsoft.Extensions.AI;

using ChatMessage = InstaConnect.Chats.Domain.Features.ChatMessages.Models.Entities.ChatMessage;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Summarizers;

internal class ChatMessageSummarizer : IChatMessageSummarizer
{
	private readonly IChatClient _chatClient;
	private readonly IApplicationMapper _mapper;
	private readonly IChatMessageSummarizeRequestFactory _requestFactory;

	public ChatMessageSummarizer(
		IChatClient chatClient,
		IApplicationMapper mapper,
		IChatMessageSummarizeRequestFactory requestFactory)
	{
		_chatClient = chatClient;
		_mapper = mapper;
		_requestFactory = requestFactory;
	}

	public async Task<Summary> SummarizeAsync(ChatMessage chatMessage, CancellationToken cancellationToken)
	{
		var serviceRequest = _requestFactory.Create(chatMessage);
		var serviceResponse = await _chatClient.GetResponseAsync(serviceRequest, cancellationToken: cancellationToken);

		var response = _mapper.Map<Summary>(serviceResponse);

		return response;
	}
}
