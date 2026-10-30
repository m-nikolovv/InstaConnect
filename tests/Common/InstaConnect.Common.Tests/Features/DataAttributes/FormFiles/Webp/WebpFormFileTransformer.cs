using System.Net.Mime;

using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;
using InstaConnect.Common.Tests.Features.Extensions;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Webp;

internal class WebpFormFileTransformer : IFormFileTransformer
{
	public IFormFile? Transform(IFormFile? value)
	{
		return DataFaker.GetFormFile(value!.FileName, value.GetContent(), MediaTypeNames.Image.Webp);
	}
}
