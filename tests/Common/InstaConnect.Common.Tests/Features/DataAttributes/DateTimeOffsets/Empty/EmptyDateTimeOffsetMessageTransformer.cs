using InstaConnect.Common.Tests.Features.DataAttributes.DateTimeOffsets.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.DateTimeOffsets.Empty;

internal class EmptyDateTimeOffsetMessageTransformer : IDateTimeOffsetMessageTransformer
{
	public string Transform<T>(Expression<Func<T, DateTimeOffset>> propertyExpression, DateTimeOffset value)
	{
		return CommonValidationErrorMessages.GetEmpty(propertyExpression.GetPropertyDisplayName());
	}
}
