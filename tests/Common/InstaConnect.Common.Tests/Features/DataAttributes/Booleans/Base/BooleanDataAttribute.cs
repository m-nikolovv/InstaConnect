namespace InstaConnect.Common.Tests.Features.DataAttributes.Booleans.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class BooleanDataAttribute : DataAttribute
{
	public IBooleanTransformer Transformer { get; }

	protected BooleanDataAttribute(IBooleanTransformer transformer)
	{
		Transformer = transformer;
	}

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
	{
		yield return new object[] { Transformer };
	}
}
