using System.Net.Http.Headers;
using System.Text;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.Tests.Features.Utilities;

public static class FormMapper
{
	extension(MultipartFormDataContent multipart)
	{
		public MultipartFormDataContent AddString(string? content, string name)
		{
			if (content == null)
			{
				return multipart;
			}

			var stringContent = new StringContent(content, Encoding.UTF8, "text/plain");
			multipart.Add(stringContent, name);

			return multipart;
		}

		public MultipartFormDataContent AddFile(IFormFile? file, string name)
		{
			if (file == null)
			{
				return multipart;
			}

			var streamContent = new StreamContent(file.OpenReadStream());
			streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
			multipart.Add(streamContent, name, file.FileName);

			return multipart;
		}

		public MultipartFormDataContent AddFiles(ICollection<IFormFile>? files, string name)
		{
			if (files == null)
			{
				return multipart;
			}

			foreach (var file in files)
			{
				multipart.AddFile(file, name);
			}

			return multipart;
		}
	}
}
