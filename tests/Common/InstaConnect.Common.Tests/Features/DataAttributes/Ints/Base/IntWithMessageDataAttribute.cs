namespace InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class IntWithMessageDataAttribute : IntDataAttribute
{
	public IIntMessageTransformer MessageTransformer { get; }

	protected IntWithMessageDataAttribute(IIntTransformer transformer, IIntMessageTransformer messageTransformer) : base(transformer)
	{
		MessageTransformer = messageTransformer;
	}

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
	{
		yield return new object[] { Transformer, MessageTransformer };
	}
}
