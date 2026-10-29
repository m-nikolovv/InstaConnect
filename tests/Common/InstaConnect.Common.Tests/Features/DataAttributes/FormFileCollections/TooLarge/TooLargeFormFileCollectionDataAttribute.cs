using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.TooLarge;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TooLargeFormFileCollectionDataAttribute : FormFileCollectionDataAttribute
{
	protected TooLargeFormFileCollectionDataAttribute(int maxSize) : base(new TooLargeFormFileCollectionTransformer(maxSize))
	{

	}
}
