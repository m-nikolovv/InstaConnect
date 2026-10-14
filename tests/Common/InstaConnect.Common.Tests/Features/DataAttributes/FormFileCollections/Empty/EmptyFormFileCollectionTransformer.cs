using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Empty;

internal class EmptyFormFileCollectionTransformer : IFormFileCollectionTransformer
{
	public ICollection<IFormFile> Transform(ICollection<IFormFile>? value)
	{
		return [];
	}
}

