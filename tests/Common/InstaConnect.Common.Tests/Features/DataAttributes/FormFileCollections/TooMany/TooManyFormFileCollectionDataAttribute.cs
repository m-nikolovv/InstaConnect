using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.TooMany;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TooManyFormFileCollectionDataAttribute : FormFileCollectionDataAttribute
{
	protected TooManyFormFileCollectionDataAttribute(int maxCount) : base(new TooManyFormFileCollectionTransformer(maxCount))
	{

	}
}
