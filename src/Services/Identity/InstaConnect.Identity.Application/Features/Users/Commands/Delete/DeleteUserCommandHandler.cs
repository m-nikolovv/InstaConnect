namespace InstaConnect.Identity.Application.Features.Users.Commands.Delete;

internal class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommandRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IUserCommandService _service;

	public DeleteUserCommandHandler(
		IApplicationMapper mapper,
		IUserCommandService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task Handle(
		DeleteUserCommandRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<DeleteUserCommand>(request);
		await _service.DeleteAsync(serviceRequest, cancellationToken);
	}
}
