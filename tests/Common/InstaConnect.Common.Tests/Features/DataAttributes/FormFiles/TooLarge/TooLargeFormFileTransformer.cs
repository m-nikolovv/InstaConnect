using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.TooLarge;

internal class TooLargeFormFileTransformer : IFormFileTransformer
{
	private readonly int _maxSize;

	public TooLargeFormFileTransformer(int maxSize)
	{
		_maxSize = maxSize;
	}

	public IFormFile Transform(IFormFile? value)
	{
		return DataFaker.GetFormFile(value!.FileName, new byte[_maxSize.Increment()], value.ContentType);
	}
}
