namespace InstaConnect.Identity.Application.Features.Users.Commands.UpdateCurrent;

public class UpdateCurrentUserCommandHandler : ICommandHandler<UpdateCurrentUserCommandRequest, UpdateCurrentUserCommandResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IUserCommandService _service;

	public UpdateCurrentUserCommandHandler(
		IApplicationMapper mapper,
		IUserCommandService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<UpdateCurrentUserCommandResponse> Handle(
		UpdateCurrentUserCommandRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<UpdateUserCommand>(request);
		var serviceResponse = await _service.UpdateAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<UpdateCurrentUserCommandResponse>(serviceResponse);

		return response;
	}
}
