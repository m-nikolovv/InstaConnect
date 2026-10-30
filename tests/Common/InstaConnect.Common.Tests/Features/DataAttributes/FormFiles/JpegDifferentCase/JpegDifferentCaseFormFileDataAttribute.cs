using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.JpegDifferentCase;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class JpegDifferentCaseFormFileDataAttribute : FormFileDataAttribute
{
	protected JpegDifferentCaseFormFileDataAttribute() : base(new JpegDifferentCaseFormFileTransformer())
	{

	}
}
