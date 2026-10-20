using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Follows.Application.Features.Users.Commands.Add;

internal class AddUserCommandHandler : ICommandHandler<AddUserCommandRequest, AddUserCommandResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IUserCommandService _userService;

	public AddUserCommandHandler(
		IApplicationMapper mapper,
		IUserCommandService userService)
	{
		_mapper = mapper;
		_userService = userService;
	}

	public async Task<AddUserCommandResponse> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<AddUserCommand>(request);
		var serviceResponse = await _userService.AddAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<AddUserCommandResponse>(serviceResponse);

		return response;
	}
}
