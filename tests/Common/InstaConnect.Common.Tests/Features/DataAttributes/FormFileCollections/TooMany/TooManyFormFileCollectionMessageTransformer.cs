using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.TooMany;

internal class TooManyFormFileCollectionMessageTransformer : IFormFileCollectionMessageTransformer
{
	private readonly int _maxCount;

	public TooManyFormFileCollectionMessageTransformer(int maxCount)
	{
		_maxCount = maxCount;
	}

	public string Transform<T>(Expression<Func<T, ICollection<IFormFile>>> propertyExpression, ICollection<IFormFile> value)
	{
		return CommonValidationErrorMessages.GetMaxCount(propertyExpression.GetPropertyDisplayName(), value.Count, _maxCount);
	}
}
