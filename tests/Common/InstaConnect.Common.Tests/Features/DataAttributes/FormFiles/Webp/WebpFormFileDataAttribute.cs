using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Webp;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class WebpFormFileDataAttribute : FormFileDataAttribute
{
	protected WebpFormFileDataAttribute() : base(new WebpFormFileTransformer())
	{

	}
}
