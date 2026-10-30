using System.Net.Mime;

using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;
using InstaConnect.Common.Tests.Features.Extensions;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.InvalidContentType;

internal class InvalidContentTypeFormFileTransformer : IFormFileTransformer
{
	public IFormFile? Transform(IFormFile? value)
	{
		return DataFaker.GetFormFile(value!.FileName, value.GetContent(), MediaTypeNames.Text.Plain);
	}
}
