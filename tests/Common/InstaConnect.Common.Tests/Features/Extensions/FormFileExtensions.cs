using InstaConnect.Common.Domain.Features.ValueObjects.Models;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Tests.Features.Extensions;

public static class FormFileExtensions
{
	extension(IFormFile formFile)
	{
		public string GetUrlValue()
		{
			return formFile.GetUrl().Value;
		}

		public Url GetUrl()
		{
			const string Format = "https://{0}-image.com";

			return new(Format.FormatCurrentCulture(Uri.EscapeDataString(formFile.FileName)));
		}
	}

	extension(ICollection<IFormFile> formFiles)
	{
		public ICollection<string> GetUrlValues()
		{
			return [.. formFiles.GetUrls().Select(url => url.Value)];
		}

		public ICollection<Url> GetUrls()
		{
			return [.. formFiles.Select(formFile => formFile.GetUrl())];
		}

		public bool ContainsUrl(string url)
		{
			return formFiles.SingleOrDefault(formFile => url.EqualsOrdinalIgnoreCase(formFile.GetUrlValue())) != null;
		}

		public bool ContainsUrl(Url url)
		{
			return formFiles.ContainsUrl(url.Value);
		}
	}
}
