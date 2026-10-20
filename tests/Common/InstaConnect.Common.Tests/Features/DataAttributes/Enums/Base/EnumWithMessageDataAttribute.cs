namespace InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EnumWithMessageDataAttribute<TEnum> : EnumDataAttribute<TEnum>
	where TEnum : Enum
{
	public IEnumMessageTransformer<TEnum> MessageTransformer { get; }

	protected EnumWithMessageDataAttribute(
		IEnumTransformer<TEnum> transformer, IEnumMessageTransformer<TEnum> messageTransformer) : base(transformer)
	{
		MessageTransformer = messageTransformer;
	}

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
	{
		yield return new object[] { Transformer, MessageTransformer };
	}
}
