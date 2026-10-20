namespace InstaConnect.Follows.Application.Features.Follows.Commands.Add;

internal class AddFollowCommandHandler : ICommandHandler<AddFollowCommandRequest, AddFollowCommandResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IFollowCommandService _service;

	public AddFollowCommandHandler(
		IApplicationMapper mapper,
		IFollowCommandService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<AddFollowCommandResponse> Handle(AddFollowCommandRequest request, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<AddFollowCommand>(request);
		var serviceResponse = await _service.AddAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<AddFollowCommandResponse>(serviceResponse);

		return response;
	}
}
