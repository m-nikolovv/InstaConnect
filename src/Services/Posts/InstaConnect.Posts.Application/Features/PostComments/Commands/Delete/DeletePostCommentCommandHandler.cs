namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;

internal class DeletePostCommentCommandHandler : ICommandHandler<DeletePostCommentCommandRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostCommentCommandService _commentService;

	public DeletePostCommentCommandHandler(
		IApplicationMapper mapper,
		IPostCommentCommandService commentService)
	{
		_mapper = mapper;
		_commentService = commentService;
	}

	public async Task Handle(
		DeletePostCommentCommandRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<DeletePostCommentCommand>(request);
		await _commentService.DeleteAsync(serviceRequest, cancellationToken);
	}
}
