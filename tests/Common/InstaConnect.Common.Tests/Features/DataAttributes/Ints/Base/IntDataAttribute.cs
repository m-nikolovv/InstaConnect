namespace InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class IntDataAttribute : DataAttribute
{
	public IIntTransformer Transformer { get; }

	protected IntDataAttribute(IIntTransformer transformer)
	{
		Transformer = transformer;
	}

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
	{
		yield return new object[] { Transformer };
	}
}
