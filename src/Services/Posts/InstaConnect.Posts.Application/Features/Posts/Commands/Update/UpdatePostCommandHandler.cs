namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;

public class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommandRequest, UpdatePostCommandResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostCommandService _service;

	public UpdatePostCommandHandler(IApplicationMapper mapper, IPostCommandService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<UpdatePostCommandResponse> Handle(
		UpdatePostCommandRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<UpdatePostCommand>(request);
		var serviceResponse = await _service.UpdateAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<UpdatePostCommandResponse>(serviceResponse);

		return response;
	}
}
