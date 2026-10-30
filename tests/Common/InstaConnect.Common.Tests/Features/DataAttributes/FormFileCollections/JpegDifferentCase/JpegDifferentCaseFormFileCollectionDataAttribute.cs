using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.JpegDifferentCase;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class JpegDifferentCaseFormFileCollectionDataAttribute : FormFileCollectionDataAttribute
{
	protected JpegDifferentCaseFormFileCollectionDataAttribute() : base(new JpegDifferentCaseFormFileCollectionTransformer())
	{

	}
}
