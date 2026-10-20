namespace InstaConnect.Common.Tests.Features.DataAttributes.Enums.Empty;

internal class EmptyEnumMessageTransformer<TEnum> : IEnumMessageTransformer<TEnum>
	where TEnum : Enum
{
	public string Transform<T>(Expression<Func<T, TEnum>> propertyExpression, TEnum value)
	{
		return CommonValidationErrorMessages.GetEmpty(propertyExpression.GetPropertyDisplayName());
	}
}
