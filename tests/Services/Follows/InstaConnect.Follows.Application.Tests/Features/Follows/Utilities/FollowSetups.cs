using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

public static class FollowSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<Follow?> GetByIdAsync(
		FollowIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new FollowId(
							   new(id.FollowerId),
							   new(id.FollowingId)),
				cancellationToken);
		}

		public async Task<Follow?> GetByIdAsync(
		AddFollowCommandResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}
	}
}
