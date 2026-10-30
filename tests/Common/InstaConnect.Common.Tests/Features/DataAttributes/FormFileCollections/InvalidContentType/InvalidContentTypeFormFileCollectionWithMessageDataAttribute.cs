using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.InvalidContentType;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class InvalidContentTypeFormFileCollectionWithMessageDataAttribute : FormFileCollectionWithMessageDataAttribute
{
	protected InvalidContentTypeFormFileCollectionWithMessageDataAttribute(ICollection<string> contentTypes) : base(
		new InvalidContentTypeFormFileCollectionTransformer(),
		new InvalidContentTypeFormFileCollectionMessageTransformer(contentTypes))
	{
	}
}
