using System.Reflection;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class FormFileCollectionDataAttribute : DataAttribute
{
	public IFormFileCollectionTransformer Transformer { get; }

	protected FormFileCollectionDataAttribute(IFormFileCollectionTransformer transformer)
	{
		Transformer = transformer;
	}

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
	{
		yield return new object[] { Transformer };
	}
}
