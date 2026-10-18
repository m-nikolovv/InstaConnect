using System.Reflection;

using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.Emails.Abstractions;
using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Helpers;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Infrastructure.Features.Analyzers.Abstractions;
using InstaConnect.Common.Tests.Features.Extensions;

using Mapster;

using MapsterMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.AI;

namespace InstaConnect.Common.Tests.Features.Utilities;

public static class MockFactory
{
	public static CancellationToken CreateCancellationToken()
	{
		return new CancellationToken();
	}

	public static IApplicationSender CreateApplicationSender()
	{
		return Mocker.Mock<IApplicationSender>();
	}

	public static IApplicationMapper CreateMapper(params Assembly[] assemblies)
	{
		var config = new TypeAdapterConfig();
		config.Scan(assemblies);

		return new ApplicationMapper(new Mapper(config));
	}

	public static IImageHandler CreateImageHandler()
	{
		var imageHandler = Mocker.Mock<IImageHandler>();

		imageHandler
			.UploadAsync(Matcher.Any<IFormFile>(), Matcher.Any<CancellationToken>())
			.ReturnsTaskResponse<Url, IFormFile>(formFile => new(formFile.GetUrl()));

		imageHandler
			.UploadRangeAsync(Matcher.Any<ICollection<IFormFile>>(), Matcher.Any<CancellationToken>())
			.ReturnsTaskResponse<ICollection<Url>, ICollection<IFormFile>>(formFiles => [.. formFiles.Select(formFile => new Url(formFile.GetUrl()))]);

		return imageHandler;
	}

	public static IAnalyzer CreateAnalyzer()
	{
		var analyzer = Mocker.Mock<IAnalyzer>();

		analyzer
			.AnalyzeAsync(Matcher.Any<ChatMessage>(), Matcher.Any<CancellationToken>())
			.ReturnsTaskResponse<string, ChatMessage>(message => message.GetAnalysisSummary());

		return analyzer;
	}

	public static IEmailSender CreateEmailSender()
	{
		return Mocker.Mock<IEmailSender>();
	}
}
