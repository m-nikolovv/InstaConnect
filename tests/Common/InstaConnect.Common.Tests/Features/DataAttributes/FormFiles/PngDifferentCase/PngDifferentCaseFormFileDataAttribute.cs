using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.PngDifferentCase;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class PngDifferentCaseFormFileDataAttribute : FormFileDataAttribute
{
	protected PngDifferentCaseFormFileDataAttribute() : base(new PngDifferentCaseFormFileTransformer())
	{

	}
}
