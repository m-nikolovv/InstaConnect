namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class FormFileDataAttribute : DataAttribute
{
	public IFormFileTransformer Transformer { get; }

	protected FormFileDataAttribute(IFormFileTransformer transformer)
	{
		Transformer = transformer;
	}

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
	{
		yield return new object[] { Transformer };
	}
}
