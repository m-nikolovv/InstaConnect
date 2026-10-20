using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Null;

internal class NullFormFileMessageTransformer : IFormFileMessageTransformer
{
	public string Transform<T>(Expression<Func<T, IFormFile>> propertyExpression, IFormFile value)
	{
		return CommonValidationErrorMessages.GetEmpty(propertyExpression.GetPropertyDisplayName());
	}
}
