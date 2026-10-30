using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.PngDifferentCase;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class PngDifferentCaseFormFileCollectionDataAttribute : FormFileCollectionDataAttribute
{
	protected PngDifferentCaseFormFileCollectionDataAttribute() : base(new PngDifferentCaseFormFileCollectionTransformer())
	{

	}
}
