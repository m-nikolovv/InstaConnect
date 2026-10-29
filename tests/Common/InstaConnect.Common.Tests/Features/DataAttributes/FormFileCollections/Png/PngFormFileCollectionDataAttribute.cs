using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Png;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class PngFormFileCollectionDataAttribute : FormFileCollectionDataAttribute
{
	protected PngFormFileCollectionDataAttribute() : base(new PngFormFileCollectionTransformer())
	{

	}
}
