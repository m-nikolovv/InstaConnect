namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class FormFileWithMessageDataAttribute : FormFileDataAttribute
{
	public IFormFileMessageTransformer MessageTransformer { get; }

	protected FormFileWithMessageDataAttribute(IFormFileTransformer transformer, IFormFileMessageTransformer messageTransformer)
		: base(transformer)
	{
		MessageTransformer = messageTransformer;
	}

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
	{
		yield return new object[] { Transformer, MessageTransformer };
	}
}
