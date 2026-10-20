namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

internal class AddPostCommandHandler : ICommandHandler<AddPostCommandRequest, AddPostCommandResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostCommandService _service;

	public AddPostCommandHandler(IApplicationMapper mapper, IPostCommandService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<AddPostCommandResponse> Handle(AddPostCommandRequest request, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<AddPostCommand>(request);
		var serviceResponse = await _service.AddAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<AddPostCommandResponse>(serviceResponse);

		return response;
	}
}
