namespace InstaConnect.Common.Tests.Features.DataAttributes.Ints.TooLarge;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TooLargeIntDataAttribute : IntDataAttribute
{
	protected TooLargeIntDataAttribute(int maxValue) : base(new TooLargeIntTransformer(maxValue))
	{

	}
}
