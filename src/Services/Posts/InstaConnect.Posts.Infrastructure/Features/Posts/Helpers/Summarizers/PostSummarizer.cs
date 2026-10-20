namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Summarizers;

internal class PostSummarizer : IPostSummarizer
{
	private readonly IChatClient _chatClient;
	private readonly IApplicationMapper _mapper;
	private readonly IPostSummarizeRequestFactory _requestFactory;

	public PostSummarizer(
		IChatClient chatClient,
		IApplicationMapper mapper,
		IPostSummarizeRequestFactory requestFactory)
	{
		_chatClient = chatClient;
		_mapper = mapper;
		_requestFactory = requestFactory;
	}

	public async Task<Summary> SummarizeAsync(Post post, CancellationToken cancellationToken)
	{
		var serviceRequest = _requestFactory.Create(post);
		var serviceResponse = await _chatClient.GetResponseAsync(serviceRequest, cancellationToken: cancellationToken);

		var response = _mapper.Map<Summary>(serviceResponse);

		return response;
	}
}
