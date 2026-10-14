using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Infrastructure.Features.Images.Helpers;

internal class ImageHandler : IImageHandler
{
	private readonly Cloudinary _cloudinary;
	private readonly IApplicationMapper _mapper;

	public ImageHandler(
		Cloudinary cloudinary,
		IApplicationMapper mapper)
	{
		_cloudinary = cloudinary;
		_mapper = mapper;
	}

	public async Task<Image> UploadAsync(IFormFile formFile, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<ImageUploadParams>(formFile);
		var serviceResponse = await _cloudinary.UploadAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<Image>(serviceResponse);

		return response;
	}

	public async Task<ICollection<Image>> UploadRangeAsync(IEnumerable<IFormFile> formFiles, CancellationToken cancellationToken)
	{
		var response = await Task.WhenAll(formFiles.Select(formFile => UploadAsync(formFile, cancellationToken)));

		return response;
	}
}
