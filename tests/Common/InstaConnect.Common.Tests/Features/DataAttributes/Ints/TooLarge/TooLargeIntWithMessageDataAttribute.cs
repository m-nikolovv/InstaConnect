namespace InstaConnect.Common.Tests.Features.DataAttributes.Ints.TooLarge;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TooLargeIntWithMessageDataAttribute : IntWithMessageDataAttribute
{
	protected TooLargeIntWithMessageDataAttribute(int maxValue) : base(
		new TooLargeIntTransformer(maxValue),
		new TooLargeIntMessageTransformer(maxValue))
	{
	}
}
