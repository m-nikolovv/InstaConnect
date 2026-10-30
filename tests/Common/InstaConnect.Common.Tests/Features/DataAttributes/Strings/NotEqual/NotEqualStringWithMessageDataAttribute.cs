namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.NotEqual;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class NotEqualStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
	protected NotEqualStringWithMessageDataAttribute(string equalPropertyName, int maxLength, int minLength = default)
		: base(
			new NotEqualStringTransformer(maxLength, minLength),
			new NotEqualStringMessageTransformer(equalPropertyName)
		)
	{
	}
}
