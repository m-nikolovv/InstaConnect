using InstaConnect.Posts.Domain.Features.Users.Abstractions;

namespace InstaConnect.Posts.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserQueryRepository GetUserQueryRepository()
		{
			return serviceProvider.GetRequiredService<IUserQueryRepository>();
		}

		public IUserCommandRepository GetUserCommandRepository()
		{
			return serviceProvider.GetRequiredService<IUserCommandRepository>();
		}

		public IUserIncludeBuilderFactory GetUserIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IUserIncludeBuilderFactory>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IUserQueryRepository GetUserQueryRepository()
		{
			return serviceScope.ServiceProvider.GetUserQueryRepository();
		}

		public IUserCommandRepository GetUserCommandRepository()
		{
			return serviceScope.ServiceProvider.GetUserCommandRepository();
		}

		public IUserIncludeBuilderFactory GetUserIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetUserIncludeBuilderFactory();
		}

		public async Task<User?> GetByIdAsync(
			UserId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetUserIncludeBuilderFactory().Create().WithPosts().WithPostLikes().WithPostComments().WithPostCommentLikes().Build();

			return (await serviceScope.GetUserCommandRepository().GetByIdAsync(id, include, cancellationToken)).SetPosts().SetPostLikes().SetPostComments().SetPostCommentLikes();
		}

		public async Task AddAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetUserCommandRepository().AddAsync(user, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<User> users,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetUserCommandRepository().AddRangeAsync(users, cancellationToken);
		}

		public async Task DeleteAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetUserCommandRepository().DeleteAsync(user, cancellationToken);
		}
	}
}
