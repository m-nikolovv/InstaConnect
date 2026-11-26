using InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Domain.Features.Follows.Abstractions;

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

		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllFollowsQuery query,
			CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOne().GetAllAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForFollowingAsync(
			GetAllFollowsForFollowingQueryRequest request,
			CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOneGetAllForFollowingAsync(request.IsGetAllFollowsForFollowingQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForFollowingAsync(
			GetAllFollowsForFollowingQuery query,
			CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOne().GetAllForFollowingAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetFollowByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetFollowByIdQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetFollowByIdQuery query,
			CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOne().GetByIdAsync(query, cancellationToken);
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

		public async Task ShouldHaveReceivedOneAddAsync(
			AddFollowCommand command,
			CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteFollowCommandRequest request,
			CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOneDeleteAsync(request.IsDeleteFollowCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteFollowCommand command,
			CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOne().DeleteAsync(command, cancellationToken);
		}
	}
}
