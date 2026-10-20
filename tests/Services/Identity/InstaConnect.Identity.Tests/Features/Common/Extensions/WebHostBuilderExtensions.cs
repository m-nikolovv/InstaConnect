using InstaConnect.Identity.Infrastructure.Features.Common.Models.Options;

using Microsoft.AspNetCore.Hosting;

namespace InstaConnect.Identity.Tests.Features.Common.Extensions;

public static class WebHostBuilderExtensions
{
	extension(IWebHostBuilder webHostBuilder)
	{
		public void UpdateAdminConfiguration()
		{
			webHostBuilder.UseSetting(
				AdminOptions.SectionName.ToSectionKey(nameof(AdminOptions.Email)),
				IdentityMockValues.AdminEmail);

			webHostBuilder.UseSetting(
				AdminOptions.SectionName.ToSectionKey(nameof(AdminOptions.Password)),
				IdentityMockValues.AdminPassword);
		}
	}
}
