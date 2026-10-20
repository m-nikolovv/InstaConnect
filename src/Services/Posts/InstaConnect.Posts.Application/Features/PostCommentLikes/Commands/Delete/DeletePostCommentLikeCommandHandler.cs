namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;

internal class DeletePostCommentLikeCommandHandler : ICommandHandler<DeletePostCommentLikeCommandRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostCommentLikeCommandService _commentLikeService;

	public DeletePostCommentLikeCommandHandler(
		IApplicationMapper mapper,
		IPostCommentLikeCommandService commentLikeService)
	{
		_mapper = mapper;
		_commentLikeService = commentLikeService;
	}

	public async Task Handle(
		DeletePostCommentLikeCommandRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<DeletePostCommentLikeCommand>(request);
		await _commentLikeService.DeleteAsync(serviceRequest, cancellationToken);
	}
}
