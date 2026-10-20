namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Add;

internal class AddPostCommentCommandHandler : ICommandHandler<AddPostCommentCommandRequest, AddPostCommentCommandResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostCommentCommandService _commentService;

	public AddPostCommentCommandHandler(
		IApplicationMapper mapper,
		IPostCommentCommandService commentService)
	{
		_mapper = mapper;
		_commentService = commentService;
	}

	public async Task<AddPostCommentCommandResponse> Handle(AddPostCommentCommandRequest request, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<AddPostCommentCommand>(request);
		var serviceResponse = await _commentService.AddAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<AddPostCommentCommandResponse>(serviceResponse);

		return response;
	}
}
