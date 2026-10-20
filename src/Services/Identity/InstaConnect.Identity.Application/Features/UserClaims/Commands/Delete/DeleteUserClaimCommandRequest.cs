using InstaConnect.Common.Domain.Features.AccessTokens.Models;

namespace InstaConnect.Identity.Application.Features.UserClaims.Commands.Delete;

public record DeleteUserClaimCommandRequest(string Id, ApplicationClaims Claim) : ICommandRequest;
