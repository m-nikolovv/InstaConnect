using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Jpeg;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class JpegFormFileCollectionDataAttribute : FormFileCollectionDataAttribute
{
	protected JpegFormFileCollectionDataAttribute() : base(new JpegFormFileCollectionTransformer())
	{

	}
}
