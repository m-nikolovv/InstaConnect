using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Posts.Application.Features.Users.Commands.Update;

internal class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IUserCommandService _userService;

	public UpdateUserCommandHandler(
		IApplicationMapper mapper,
		IUserCommandService userService)
	{
		_mapper = mapper;
		_userService = userService;
	}

	public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<UpdateUserCommand>(request);
		var serviceResponse = await _userService.UpdateAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<UpdateUserCommandResponse>(serviceResponse);

		return response;
	}
}
