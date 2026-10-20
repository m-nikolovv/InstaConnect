using InstaConnect.Common.Application.Features.AccessTokens.Models;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.DeleteCurrent;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;
using InstaConnect.Identity.Application.Features.RefreshTokens.Models;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Application.Features.RefreshTokens.Mappings;

public class RefreshTokenApplicationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<SessionToken, SessionTokenCommandResponse>()
			.ConstructUsing(src => new(
					src.Id.Adapt<RefreshTokenIdCommandResponse>(config),
					src.AccessToken.Adapt<AccessTokenCommandResponse>(config),
					src.ExpiresAtUtc));

		config.NewConfig<IssueRefreshTokenCommandRequest, IssueRefreshTokenCommand>()
			.ConstructUsing(src => new(
				new(src.Name),
				src.Password));

		config.NewConfig<SessionToken, IssueRefreshTokenCommandResponse>()
			.ConstructUsing(src => new(src.Adapt<SessionTokenCommandResponse>(config)));

		config.NewConfig<RotateRefreshTokenCommandRequest, RotateRefreshTokenCommand>()
			.ConstructUsing(src => new(
									   new(
										   new(src.Id),
										   src.Value)));

		config.NewConfig<SessionToken, RotateRefreshTokenCommandResponse>()
			.ConstructUsing(src => new(src.Adapt<SessionTokenCommandResponse>(config)));

		config.NewConfig<DeleteCurrentRefreshTokenCommandRequest, DeleteRefreshTokenCommand>()
			.ConstructUsing(src => new(
									   new(
										   new(src.Id),
										   src.Value)));

		config.NewConfig<RefreshTokenId, RefreshTokenIdCommandResponse>()
			.ConstructUsing(src => new(
				src.Id.Id,
				src.Value));
	}
}
