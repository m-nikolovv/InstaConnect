using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Png;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class PngFormFileDataAttribute : FormFileDataAttribute
{
	protected PngFormFileDataAttribute() : base(new PngFormFileTransformer())
	{

	}
}
