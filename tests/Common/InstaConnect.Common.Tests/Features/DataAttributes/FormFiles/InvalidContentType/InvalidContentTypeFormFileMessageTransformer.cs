using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.InvalidContentType;

internal class InvalidContentTypeFormFileMessageTransformer : IFormFileMessageTransformer
{
	private readonly ICollection<string> _contentTypes;

	public InvalidContentTypeFormFileMessageTransformer(ICollection<string> contentTypes)
	{
		_contentTypes = contentTypes;
	}

	public string Transform<T>(Expression<Func<T, IFormFile>> propertyExpression, IFormFile value)
	{
		return CommonValidationErrorMessages.GetInvalidContentType(propertyExpression.GetPropertyDisplayName(), _contentTypes);
	}
}
