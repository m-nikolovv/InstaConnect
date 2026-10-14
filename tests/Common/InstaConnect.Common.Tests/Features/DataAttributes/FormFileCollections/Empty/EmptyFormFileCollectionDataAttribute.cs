using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyFormFileCollectionDataAttribute : FormFileCollectionDataAttribute
{
	protected EmptyFormFileCollectionDataAttribute() : base(new EmptyFormFileCollectionTransformer())
	{

	}
}
