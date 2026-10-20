namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class StringWithMessageDataAttribute : StringDataAttribute
{
	public IStringMessageTransformer MessageTransformer { get; }

	protected StringWithMessageDataAttribute(IStringTransformer transformer, IStringMessageTransformer messageTransformer)
		: base(transformer)
	{
		MessageTransformer = messageTransformer;
	}

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
	{
		yield return new object[] { Transformer, MessageTransformer };
	}
}
