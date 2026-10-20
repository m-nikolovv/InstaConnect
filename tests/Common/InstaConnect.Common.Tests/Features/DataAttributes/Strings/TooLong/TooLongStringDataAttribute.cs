namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.TooLong;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TooLongStringDataAttribute : StringDataAttribute
{
	protected TooLongStringDataAttribute(int maxLength) : base(new TooLongStringTransformer(maxLength))
	{

	}
}
