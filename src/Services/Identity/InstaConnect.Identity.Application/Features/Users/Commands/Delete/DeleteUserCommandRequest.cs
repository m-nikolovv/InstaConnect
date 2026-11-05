namespace InstaConnect.Identity.Application.Features.Users.Commands.Delete;

public record DeleteUserCommandRequest(string Id) : ICommandRequest;
