using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserClaimQueryRepository GetClaimQueryRepository()
		{
			return serviceProvider.GetRequiredService<IUserClaimQueryRepository>();
		}

		public IUserClaimCommandRepository GetClaimCommandRepository()
		{
			return serviceProvider.GetRequiredService<IUserClaimCommandRepository>();
		}

		public IUserClaimIncludeBuilderFactory GetClaimIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IUserClaimIncludeBuilderFactory>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IUserClaimQueryRepository GetClaimQueryRepository()
		{
			return serviceScope.ServiceProvider.GetClaimQueryRepository();
		}

		public IUserClaimCommandRepository GetClaimCommandRepository()
		{
			return serviceScope.ServiceProvider.GetClaimCommandRepository();
		}

		public IUserClaimIncludeBuilderFactory GetClaimIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetClaimIncludeBuilderFactory();
		}

		public async Task<UserClaim?> GetByIdAsync(
			UserClaimId id,
			CancellationToken cancellationToken)
		{
			var claimInclude = serviceScope.GetClaimIncludeBuilderFactory().Create().WithUser().Build();

			return (await serviceScope.GetClaimCommandRepository().GetByIdAsync(id, claimInclude, cancellationToken)).SetUser();
		}

		public async Task AddAsync(
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetClaimCommandRepository().AddAsync(userClaim, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetClaimCommandRepository().AddRangeAsync(userClaims, cancellationToken);
		}

		public async Task DeleteAsync(
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetClaimCommandRepository().DeleteAsync(userClaim, cancellationToken);
		}
	}
}
