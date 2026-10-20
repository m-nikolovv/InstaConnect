using InstaConnect.Follows.Presentation.Features.Follows.Abstractions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace InstaConnect.Follows.Presentation.Features.Follows.Helpers;

[Authorize]
public class FollowHub : Hub<IFollowHubClient>;
