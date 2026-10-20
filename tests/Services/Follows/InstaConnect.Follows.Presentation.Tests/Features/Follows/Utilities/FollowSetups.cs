using InstaConnect.Common.Presentation.Tests.Features.Extensions;
using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;
using InstaConnect.Follows.Presentation.Features.Follows.Controllers.v1;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

public static class FollowSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public FollowController GetFollowController()
		{
			return serviceProvider.GetRequiredService<FollowController>();
		}

		public FollowingFollowController GetFollowingFollowController()
		{
			return serviceProvider.GetRequiredService<FollowingFollowController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public FollowController GetFollowController()
		{
			return serviceScope.ServiceProvider.GetFollowController();
		}

		public FollowingFollowController GetFollowingFollowController()
		{
			return serviceScope.ServiceProvider.GetFollowingFollowController();
		}

		internal async Task<Follow?> GetByIdAsync(
		FollowIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new FollowId(
							   new(id.FollowerId),
							   new(id.FollowingId)),
				cancellationToken);
		}

		public async Task<Follow?> GetByIdAsync(
		AddFollowApiResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<Follow?> GetByIdAsync(
		ActionResult<AddFollowApiResponse> response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}
	}
}
