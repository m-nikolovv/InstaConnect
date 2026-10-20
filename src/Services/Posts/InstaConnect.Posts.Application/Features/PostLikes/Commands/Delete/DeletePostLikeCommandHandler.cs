namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;

internal class DeletePostLikeCommandHandler : ICommandHandler<DeletePostLikeCommandRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostLikeCommandService _likeService;

	public DeletePostLikeCommandHandler(
		IApplicationMapper mapper,
		IPostLikeCommandService likeService)
	{
		_mapper = mapper;
		_likeService = likeService;
	}

	public async Task Handle(
		DeletePostLikeCommandRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<DeletePostLikeCommand>(request);
		await _likeService.DeleteAsync(serviceRequest, cancellationToken);
	}
}
