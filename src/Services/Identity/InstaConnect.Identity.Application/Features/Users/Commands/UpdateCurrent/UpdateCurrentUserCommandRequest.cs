using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Application.Features.Users.Commands.UpdateCurrent;

public record UpdateCurrentUserCommandRequest(
	string Id,
	string Email,
	string FirstName,
	string LastName,
	string Name,
	IFormFile? ProfileImage) : ICommandRequest<UpdateCurrentUserCommandResponse>;
