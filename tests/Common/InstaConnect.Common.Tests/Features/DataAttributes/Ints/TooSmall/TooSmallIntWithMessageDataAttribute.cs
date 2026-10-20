namespace InstaConnect.Common.Tests.Features.DataAttributes.Ints.TooSmall;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TooSmallIntWithMessageDataAttribute : IntWithMessageDataAttribute
{
	protected TooSmallIntWithMessageDataAttribute(int minValue) : base(
		new TooSmallIntTransformer(minValue),
		new TooSmallIntMessageTransformer(minValue))
	{
	}
}
