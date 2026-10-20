namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;

internal class AddPostLikeCommandHandler : ICommandHandler<AddPostLikeCommandRequest, AddPostLikeCommandResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostLikeCommandService _likeService;

	public AddPostLikeCommandHandler(
		IApplicationMapper mapper,
		IPostLikeCommandService likeService)
	{
		_mapper = mapper;
		_likeService = likeService;
	}

	public async Task<AddPostLikeCommandResponse> Handle(AddPostLikeCommandRequest request, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<AddPostLikeCommand>(request);
		var serviceResponse = await _likeService.AddAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<AddPostLikeCommandResponse>(serviceResponse);

		return response;
	}
}
