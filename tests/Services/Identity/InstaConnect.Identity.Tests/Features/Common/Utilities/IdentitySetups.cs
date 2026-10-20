using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

namespace InstaConnect.Identity.Tests.Features.Common.Utilities;

public static class IdentitySetups
{

	extension(IServiceProvider serviceProvider)
	{
		public IPasswordHasher GetPasswordHasher()
		{
			return serviceProvider.GetRequiredService<IPasswordHasher>();
		}

		public IAccessTokenGenerator GetAccessTokenGenerator()
		{
			return serviceProvider.GetRequiredService<IAccessTokenGenerator>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPasswordHasher GetPasswordHasher()
		{
			return serviceScope.ServiceProvider.GetPasswordHasher();
		}
		public IAccessTokenGenerator GetAccessTokenGenerator()
		{
			return serviceScope.ServiceProvider.GetAccessTokenGenerator();
		}
	}
}
