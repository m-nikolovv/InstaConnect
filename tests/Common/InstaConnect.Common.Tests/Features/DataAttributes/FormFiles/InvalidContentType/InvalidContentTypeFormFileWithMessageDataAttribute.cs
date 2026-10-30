using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.InvalidContentType;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class InvalidContentTypeFormFileWithMessageDataAttribute : FormFileWithMessageDataAttribute
{
	protected InvalidContentTypeFormFileWithMessageDataAttribute(ICollection<string> contentTypes) : base(
		new InvalidContentTypeFormFileTransformer(),
		new InvalidContentTypeFormFileMessageTransformer(contentTypes))
	{
	}
}
