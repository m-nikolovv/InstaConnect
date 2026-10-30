using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.TooLarge;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TooLargeFormFileWithMessageDataAttribute : FormFileWithMessageDataAttribute
{
	protected TooLargeFormFileWithMessageDataAttribute(int maxSize) : base(
		new TooLargeFormFileTransformer(maxSize),
		new TooLargeFormFileMessageTransformer(maxSize))
	{
	}
}
