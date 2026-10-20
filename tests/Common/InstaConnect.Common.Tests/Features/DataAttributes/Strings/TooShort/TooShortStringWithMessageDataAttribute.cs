namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.TooShort;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TooShortStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
	protected TooShortStringWithMessageDataAttribute(int minValue)
		: base(new TooShortStringTransformer(minValue),
			   new TooShortStringMessageTransformer(minValue))
	{
	}
}
