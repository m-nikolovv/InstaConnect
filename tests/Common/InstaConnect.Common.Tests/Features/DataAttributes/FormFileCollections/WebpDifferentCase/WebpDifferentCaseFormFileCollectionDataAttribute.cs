using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.WebpDifferentCase;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class WebpDifferentCaseFormFileCollectionDataAttribute : FormFileCollectionDataAttribute
{
	protected WebpDifferentCaseFormFileCollectionDataAttribute() : base(new WebpDifferentCaseFormFileCollectionTransformer())
	{

	}
}
