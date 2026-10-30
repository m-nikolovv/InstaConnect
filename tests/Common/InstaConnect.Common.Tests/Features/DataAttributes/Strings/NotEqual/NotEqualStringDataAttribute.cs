namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.NotEqual;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class NotEqualStringDataAttribute : StringDataAttribute
{
	protected NotEqualStringDataAttribute(int maxLength, int minLength = default) : base(new NotEqualStringTransformer(maxLength, minLength))
	{

	}
}
