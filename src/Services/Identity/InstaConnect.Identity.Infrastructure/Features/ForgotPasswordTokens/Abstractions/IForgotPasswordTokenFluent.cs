using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenFluent : IMongoDbFluent<ForgotPasswordToken>
{
	public IForgotPasswordTokenFluent Match(ForgotPasswordTokenId filter);
	public IForgotPasswordTokenFluent Match(IEnumerable<ForgotPasswordTokenId> filter);
	public IForgotPasswordTokenFluent ApplyIncludes(ForgotPasswordTokenInclude include);
}
