using CloudinaryDotNet.Actions;

using InstaConnect.Common.Domain.Features.ValueObjects.Models;

using Mapster;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Infrastructure.Features.Images.Mappings;

public class ImageInfrastructureMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<IFormFile, ImageUploadParams>()
			.ConstructUsing(src => new()
			{
				File = new(src.FileName, src.OpenReadStream())
			});

		config.NewConfig<ImageUploadResult, Url>()
			.ConstructUsing(src => new(src.Url.AbsoluteUri));
	}
}
