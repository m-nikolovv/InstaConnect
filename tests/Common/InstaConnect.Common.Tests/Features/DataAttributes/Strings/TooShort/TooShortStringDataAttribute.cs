namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.TooShort;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TooShortStringDataAttribute : StringDataAttribute
{
	protected TooShortStringDataAttribute(int minLength) : base(new TooShortStringTransformer(minLength))
	{

	}
}
