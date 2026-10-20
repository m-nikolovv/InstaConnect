namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class FormFileCollectionWithMessageDataAttribute : FormFileCollectionDataAttribute
{
	public IFormFileCollectionMessageTransformer MessageTransformer { get; }

	protected FormFileCollectionWithMessageDataAttribute(IFormFileCollectionTransformer transformer, IFormFileCollectionMessageTransformer messageTransformer)
		: base(transformer)
	{
		MessageTransformer = messageTransformer;
	}

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
	{
		yield return new object[] { Transformer, MessageTransformer };
	}
}
