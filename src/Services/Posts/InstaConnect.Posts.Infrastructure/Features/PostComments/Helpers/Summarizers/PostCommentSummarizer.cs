using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;

using Microsoft.Extensions.AI;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Summarizers;

internal class PostCommentSummarizer : IPostCommentSummarizer
{
	private readonly IChatClient _chatClient;
	private readonly IApplicationMapper _mapper;
	private readonly IPostCommentSummarizeRequestFactory _requestFactory;

	public PostCommentSummarizer(
		IChatClient chatClient,
		IApplicationMapper mapper,
		IPostCommentSummarizeRequestFactory requestFactory)
	{
		_chatClient = chatClient;
		_mapper = mapper;
		_requestFactory = requestFactory;
	}

	public async Task<Summary> SummarizeAsync(PostComment postComment, CancellationToken cancellationToken)
	{
		var serviceRequest = _requestFactory.Create(postComment);
		var serviceResponse = await _chatClient.GetResponseAsync(serviceRequest, cancellationToken: cancellationToken);

		var response = _mapper.Map<Summary>(serviceResponse);

		return response;
	}
}
