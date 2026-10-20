namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Update;

public class UpdatePostCommentCommandHandler : ICommandHandler<UpdatePostCommentCommandRequest, UpdatePostCommentCommandResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostCommentCommandService _commentService;

	public UpdatePostCommentCommandHandler(
		IApplicationMapper mapper,
		IPostCommentCommandService commentService)
	{
		_mapper = mapper;
		_commentService = commentService;
	}

	public async Task<UpdatePostCommentCommandResponse> Handle(
		UpdatePostCommentCommandRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<UpdatePostCommentCommand>(request);
		var serviceResponse = await _commentService.UpdateAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<UpdatePostCommentCommandResponse>(serviceResponse);

		return response;
	}
}
