using InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Assertions;

public static class FollowMockAssertions
{
	extension(IFollowQueryService followService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
		GetAllFollowsQueryRequest request,
		CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOneGetAllAsync(request.IsGetAllFollowsQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForFollowingAsync(
			GetAllFollowsForFollowingQueryRequest request,
			CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOneGetAllForFollowingAsync(request.IsGetAllFollowsForFollowingQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetFollowByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetFollowByIdQuery(), cancellationToken);
		}
	}

	extension(IFollowCommandService followService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
		AddFollowCommandRequest request,
		CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOneAddAsync(request.IsAddFollowCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteFollowCommandRequest request,
			CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOneDeleteAsync(request.IsDeleteFollowCommand(), cancellationToken);
		}
	}
}
