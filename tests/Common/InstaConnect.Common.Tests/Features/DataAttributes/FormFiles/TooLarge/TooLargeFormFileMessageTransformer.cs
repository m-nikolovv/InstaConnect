using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.TooLarge;

internal class TooLargeFormFileMessageTransformer : IFormFileMessageTransformer
{
	private readonly int _maxSize;

	public TooLargeFormFileMessageTransformer(int maxSize)
	{
		_maxSize = maxSize;
	}

	public string Transform<T>(Expression<Func<T, IFormFile?>> propertyExpression, IFormFile? value)
	{
		return CommonValidationErrorMessages.GetMaxFileSize(propertyExpression.GetPropertyDisplayName(), value!.Length, _maxSize);
	}
}
