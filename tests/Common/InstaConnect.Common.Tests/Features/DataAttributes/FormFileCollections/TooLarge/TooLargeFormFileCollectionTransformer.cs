using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.TooLarge;

internal class TooLargeFormFileCollectionTransformer : IFormFileCollectionTransformer
{
	private readonly int _maxSize;

	public TooLargeFormFileCollectionTransformer(int maxSize)
	{
		_maxSize = maxSize;
	}

	public ICollection<IFormFile> Transform(ICollection<IFormFile>? value)
	{
		return [.. value!.Select(formFile => DataFaker.GetFormFile(formFile.FileName, new byte[_maxSize.Increment()], formFile.ContentType))];
	}
}
