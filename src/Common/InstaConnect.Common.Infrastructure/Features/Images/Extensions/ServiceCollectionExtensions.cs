using CloudinaryDotNet;

using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Images.Helpers;
using InstaConnect.Common.Infrastructure.Features.Images.Models;

namespace InstaConnect.Common.Infrastructure.Features.Images.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddImages(IConfiguration configuration)
		{
			serviceCollection.AddValidatedOptions<CloudinaryOptions>(CloudinaryOptions.SectionName);
			var options = configuration.GetOptions<CloudinaryOptions>(CloudinaryOptions.SectionName);

			serviceCollection.AddScoped(_ => new Cloudinary(new Account(
				options.CloudName,
				options.ApiKey,
				options.ApiSecret)));

			serviceCollection.AddScoped<IImageHandler, ImageHandler>();

			return serviceCollection;
		}
	}
}
