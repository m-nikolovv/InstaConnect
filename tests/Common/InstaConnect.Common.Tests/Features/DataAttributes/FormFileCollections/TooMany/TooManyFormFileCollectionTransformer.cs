using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Common.Tests.Features.Extensions;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.TooMany;

internal class TooManyFormFileCollectionTransformer : IFormFileCollectionTransformer
{
	private readonly int _maxCount;

	public TooManyFormFileCollectionTransformer(int maxCount)
	{
		_maxCount = maxCount;
	}

	public ICollection<IFormFile> Transform(ICollection<IFormFile>? value)
	{
		return [.. Enumerable.Range(default, _maxCount.Increment())
			.Select(index => value!.ElementAt(index % value!.Count))
			.Select(formFile => DataFaker.GetFormFile(formFile.FileName, formFile.GetContent(), formFile.ContentType))];
	}
}
