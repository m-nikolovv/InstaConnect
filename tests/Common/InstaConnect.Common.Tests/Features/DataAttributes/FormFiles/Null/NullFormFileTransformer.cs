using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Null;

internal class NullFormFileTransformer : IFormFileTransformer
{
	public IFormFile? Transform(IFormFile? value)
	{
		return null;
	}
}

