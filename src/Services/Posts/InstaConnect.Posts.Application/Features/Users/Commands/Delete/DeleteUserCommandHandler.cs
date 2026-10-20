using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Posts.Application.Features.Users.Commands.Delete;

internal class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommandRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IUserCommandService _userService;

	public DeleteUserCommandHandler(
		IApplicationMapper mapper,
		IUserCommandService userService)
	{
		_mapper = mapper;
		_userService = userService;
	}

	public async Task Handle(
		DeleteUserCommandRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<DeleteUserCommand>(request);
		await _userService.DeleteAsync(serviceRequest, cancellationToken);
	}
}
