namespace InstaConnect.Common.Tests.Features.DataAttributes.Booleans.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class BooleanWithMessageDataAttribute : BooleanDataAttribute
{
	public IBooleanMessageTransformer MessageTransformer { get; }

	protected BooleanWithMessageDataAttribute(IBooleanTransformer transformer, IBooleanMessageTransformer messageTransformer)
		: base(transformer)
	{
		MessageTransformer = messageTransformer;
	}

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
	{
		yield return new object[] { Transformer, MessageTransformer };
	}
}
