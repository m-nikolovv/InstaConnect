using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyFormFileCollectionWithMessageDataAttribute : FormFileCollectionWithMessageDataAttribute
{
	protected EmptyFormFileCollectionWithMessageDataAttribute() : base(
		new EmptyFormFileCollectionTransformer(),
		new EmptyFormFileCollectionMessageTransformer())
	{
	}
}
