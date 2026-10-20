using InstaConnect.Common.Application.Features.AccessTokens.Models;
using InstaConnect.Common.Presentation.Features.AccessTokens.Models.Responses;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.DeleteCurrent;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;
using InstaConnect.Identity.Application.Features.RefreshTokens.Models;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Models.Responses;

namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Mappings;

internal class RefreshTokenPresentationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<SessionTokenCommandResponse, SetRefreshTokenCookieApiRequest>()
			.ConstructUsing(src => new(src.Id.Id, src.Id.Value, src.ExpiresAtUtc));

		config.NewConfig<IssueRefreshTokenApiRequest, IssueRefreshTokenCommandRequest>()
			.ConstructUsing(src => new(
									   src.Name,
									   src.Body.Password));

		config.NewConfig<IssueRefreshTokenCommandResponse, IssueRefreshTokenApiResponse>()
			.ConstructUsing(src => new(src.Response.AccessToken.Adapt<AccessTokenApiResponse>(config)));

		config.NewConfig<RotateRefreshTokenApiRequest, RotateRefreshTokenCommandRequest>()
			.ConstructUsing(src => new(
				src.Id,
				src.Value));

		config.NewConfig<RotateRefreshTokenCommandResponse, RotateRefreshTokenApiResponse>()
			.ConstructUsing(src => new(src.Response.AccessToken.Adapt<AccessTokenApiResponse>(config)));

		config.NewConfig<DeleteCurrentRefreshTokenApiRequest, DeleteCurrentRefreshTokenCommandRequest>()
			.ConstructUsing(src => new(
				src.Id,
				src.Value));

		config.NewConfig<AccessTokenCommandResponse, AccessTokenApiResponse>()
			.ConstructUsing(src => new(
				src.Value,
				src.ExpiresAtUtc));
	}
}
