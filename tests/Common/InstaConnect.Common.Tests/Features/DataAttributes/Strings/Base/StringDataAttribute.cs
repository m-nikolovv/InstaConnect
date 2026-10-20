namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class StringDataAttribute : DataAttribute
{
	public IStringTransformer Transformer { get; }

	protected StringDataAttribute(IStringTransformer transformer)
	{
		Transformer = transformer;
	}

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
	{
		yield return new object[] { Transformer };
	}
}
