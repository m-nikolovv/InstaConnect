using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.InvalidContentType;

internal class InvalidContentTypeFormFileCollectionMessageTransformer : IFormFileCollectionMessageTransformer
{
	private readonly ICollection<string> _contentTypes;

	public InvalidContentTypeFormFileCollectionMessageTransformer(ICollection<string> contentTypes)
	{
		_contentTypes = contentTypes;
	}

	public string Transform<T>(Expression<Func<T, ICollection<IFormFile>>> propertyExpression, ICollection<IFormFile> value)
	{
		return CommonValidationErrorMessages.GetInvalidContentType(propertyExpression.GetPropertyDisplayName(), _contentTypes);
	}
}
