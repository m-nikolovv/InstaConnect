using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.TooLarge;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TooLargeFormFileDataAttribute : FormFileDataAttribute
{
	protected TooLargeFormFileDataAttribute(int maxSize) : base(new TooLargeFormFileTransformer(maxSize))
	{

	}
}
