using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Webp;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class WebpFormFileCollectionDataAttribute : FormFileCollectionDataAttribute
{
	protected WebpFormFileCollectionDataAttribute() : base(new WebpFormFileCollectionTransformer())
	{

	}
}
