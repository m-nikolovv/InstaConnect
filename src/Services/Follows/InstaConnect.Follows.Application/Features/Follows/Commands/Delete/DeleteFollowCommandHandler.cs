namespace InstaConnect.Follows.Application.Features.Follows.Commands.Delete;

internal class DeleteFollowCommandHandler : ICommandHandler<DeleteFollowCommandRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IFollowCommandService _service;

	public DeleteFollowCommandHandler(
		IApplicationMapper mapper,
		IFollowCommandService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task Handle(
		DeleteFollowCommandRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<DeleteFollowCommand>(request);
		await _service.DeleteAsync(serviceRequest, cancellationToken);
	}
}
