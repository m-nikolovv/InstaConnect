using InstaConnect.Follows.Domain.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public static class FollowSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IFollowQueryRepository GetFollowQueryRepository()
		{
			return serviceProvider.GetRequiredService<IFollowQueryRepository>();
		}

		public IFollowCommandRepository GetFollowCommandRepository()
		{
			return serviceProvider.GetRequiredService<IFollowCommandRepository>();
		}

		public IFollowIncludeBuilderFactory GetFollowIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IFollowIncludeBuilderFactory>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IFollowQueryRepository GetFollowQueryRepository()
		{
			return serviceScope.ServiceProvider.GetFollowQueryRepository();
		}

		public IFollowCommandRepository GetFollowCommandRepository()
		{
			return serviceScope.ServiceProvider.GetFollowCommandRepository();
		}

		public IFollowIncludeBuilderFactory GetFollowIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetFollowIncludeBuilderFactory();
		}

		public async Task<Follow?> GetByIdAsync(
			FollowId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetFollowIncludeBuilderFactory().Create().WithFollower().WithFollowing().Build();

			return (await serviceScope.GetFollowCommandRepository().GetByIdAsync(id, include, cancellationToken)).SetFollower().SetFollowing();
		}

		public async Task AddAsync(
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetFollowCommandRepository().AddAsync(follow, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetFollowCommandRepository().AddRangeAsync(follows, cancellationToken);
		}

		public async Task DeleteAsync(
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetFollowCommandRepository().DeleteAsync(follow, cancellationToken);
		}
	}
}
