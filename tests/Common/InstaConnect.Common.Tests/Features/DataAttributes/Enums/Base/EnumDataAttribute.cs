namespace InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EnumDataAttribute<TEnum> : DataAttribute
	where TEnum : Enum
{
	public IEnumTransformer<TEnum> Transformer { get; }

	protected EnumDataAttribute(IEnumTransformer<TEnum> transformer)
	{
		Transformer = transformer;
	}

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
	{
		yield return new object[] { Transformer };
	}
}
