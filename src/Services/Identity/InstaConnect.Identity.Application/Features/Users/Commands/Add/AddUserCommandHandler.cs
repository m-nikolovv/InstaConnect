namespace InstaConnect.Identity.Application.Features.Users.Commands.Add;

internal class AddUserCommandHandler : ICommandHandler<AddUserCommandRequest, AddUserCommandResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IUserCommandService _service;

	public AddUserCommandHandler(
		IApplicationMapper mapper,
		IUserCommandService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<AddUserCommandResponse> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<AddUserCommand>(request);
		var serviceResponse = await _service.AddAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<AddUserCommandResponse>(serviceResponse);

		return response;
	}
}
