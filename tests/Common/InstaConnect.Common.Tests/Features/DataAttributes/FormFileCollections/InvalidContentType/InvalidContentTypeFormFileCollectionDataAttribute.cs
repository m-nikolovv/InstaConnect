using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.InvalidContentType;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class InvalidContentTypeFormFileCollectionDataAttribute : FormFileCollectionDataAttribute
{
	protected InvalidContentTypeFormFileCollectionDataAttribute() : base(new InvalidContentTypeFormFileCollectionTransformer())
	{

	}
}
