using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.InvalidContentType;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class InvalidContentTypeFormFileDataAttribute : FormFileDataAttribute
{
	protected InvalidContentTypeFormFileDataAttribute() : base(new InvalidContentTypeFormFileTransformer())
	{

	}
}
