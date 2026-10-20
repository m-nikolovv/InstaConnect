using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Empty;

internal class EmptyFormFileCollectionMessageTransformer : IFormFileCollectionMessageTransformer
{
	public string Transform<T>(Expression<Func<T, ICollection<IFormFile>>> propertyExpression, ICollection<IFormFile> value)
	{
		return CommonValidationErrorMessages.GetEmpty(propertyExpression.GetPropertyDisplayName());
	}
}
