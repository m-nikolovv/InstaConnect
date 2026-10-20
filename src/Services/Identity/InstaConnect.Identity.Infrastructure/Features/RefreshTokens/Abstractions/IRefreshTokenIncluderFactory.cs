namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenIncluderFactory
	: IIncluderFactory<IdentityIncludeType, IdentityDestinationType, IdentityIncludeDescriptor, IRefreshTokenIncluder, RefreshToken>;
