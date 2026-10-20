namespace InstaConnect.Common.Tests.Features.DataAttributes.DateTimeOffsets.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DateTimeOffsetDataAttribute : DataAttribute
{
	public IDateTimeOffsetTransformer Transformer { get; }

	protected DateTimeOffsetDataAttribute(IDateTimeOffsetTransformer transformer)
	{
		Transformer = transformer;
	}

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
	{
		yield return new object[] { Transformer };
	}
}
