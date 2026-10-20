namespace InstaConnect.Identity.Application.Features.Users.Commands.DeleteCurrent;

internal class DeleteCurrentUserCommandHandler : ICommandHandler<DeleteCurrentUserCommandRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IUserCommandService _service;

	public DeleteCurrentUserCommandHandler(
		IApplicationMapper mapper,
		IUserCommandService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task Handle(
		DeleteCurrentUserCommandRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<DeleteUserCommand>(request);
		await _service.DeleteAsync(serviceRequest, cancellationToken);
	}
}
