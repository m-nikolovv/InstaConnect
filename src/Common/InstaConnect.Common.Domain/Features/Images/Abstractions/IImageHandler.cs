using InstaConnect.Common.Domain.Features.ValueObjects.Models;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Domain.Features.Images.Abstractions;

public interface IImageHandler
{
	public Task<Image> UploadAsync(IFormFile formFile, CancellationToken cancellationToken);

	public Task<ICollection<Image>> UploadRangeAsync(IEnumerable<IFormFile> formFiles, CancellationToken cancellationToken);
}
