using InstaConnect.Common.Domain.Features.ValueObjects.Models;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Domain.Features.Images.Abstractions;

public interface IImageHandler
{
	public Task<Url> UploadAsync(IFormFile formFile, CancellationToken cancellationToken);

	public Task<ICollection<Url>> UploadRangeAsync(ICollection<IFormFile> formFiles, CancellationToken cancellationToken);
}
