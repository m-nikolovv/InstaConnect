namespace InstaConnect.Posts.Application.Features.Posts.Commands.Delete;

internal class DeletePostCommandHandler : ICommandHandler<DeletePostCommandRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostCommandService _service;

	public DeletePostCommandHandler(IApplicationMapper mapper, IPostCommandService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task Handle(
		DeletePostCommandRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<DeletePostCommand>(request);
		await _service.DeleteAsync(serviceRequest, cancellationToken);
	}
}
