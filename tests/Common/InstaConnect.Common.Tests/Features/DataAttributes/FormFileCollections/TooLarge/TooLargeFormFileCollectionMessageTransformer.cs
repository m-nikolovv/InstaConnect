using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.TooLarge;

internal class TooLargeFormFileCollectionMessageTransformer : IFormFileCollectionMessageTransformer
{
	private readonly int _maxSize;

	public TooLargeFormFileCollectionMessageTransformer(int maxSize)
	{
		_maxSize = maxSize;
	}

	public string Transform<T>(Expression<Func<T, ICollection<IFormFile>>> propertyExpression, ICollection<IFormFile> value)
	{
		return CommonValidationErrorMessages.GetMaxFileSize(propertyExpression.GetPropertyDisplayName(), value.First().Length, _maxSize);
	}
}
