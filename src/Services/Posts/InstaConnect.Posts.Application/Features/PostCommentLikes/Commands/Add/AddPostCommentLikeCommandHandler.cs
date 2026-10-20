namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;

internal class AddPostCommentLikeCommandHandler : ICommandHandler<AddPostCommentLikeCommandRequest, AddPostCommentLikeCommandResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostCommentLikeCommandService _commentLikeService;

	public AddPostCommentLikeCommandHandler(
		IApplicationMapper mapper,
		IPostCommentLikeCommandService commentLikeService)
	{
		_mapper = mapper;
		_commentLikeService = commentLikeService;
	}

	public async Task<AddPostCommentLikeCommandResponse> Handle(AddPostCommentLikeCommandRequest request, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<AddPostCommentLikeCommand>(request);
		var serviceResponse = await _commentLikeService.AddAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<AddPostCommentLikeCommandResponse>(serviceResponse);

		return response;
	}
}
