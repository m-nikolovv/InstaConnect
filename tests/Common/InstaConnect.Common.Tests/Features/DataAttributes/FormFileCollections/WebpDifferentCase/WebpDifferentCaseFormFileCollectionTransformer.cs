using System.Net.Mime;

using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Common.Tests.Features.Extensions;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.WebpDifferentCase;

internal class WebpDifferentCaseFormFileCollectionTransformer : IFormFileCollectionTransformer
{
	public ICollection<IFormFile> Transform(ICollection<IFormFile>? value)
	{
		return [.. value!.Select(formFile => DataFaker.GetFormFile(formFile.FileName, formFile.GetContent(), DataFaker.GetDifferentCaseString(MediaTypeNames.Image.Webp)))];
	}
}
