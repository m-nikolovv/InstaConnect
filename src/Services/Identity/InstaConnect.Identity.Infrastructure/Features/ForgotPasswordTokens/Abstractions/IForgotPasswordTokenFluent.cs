using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenFluent : IMongoDbFluent<ForgotPasswordToken>
{
	public IForgotPasswordTokenFluent Match(ForgotPasswordTokenId filter);
	public IForgotPasswordTokenFluent Match(IEnumerable<ForgotPasswordTokenId> filter);
	public IForgotPasswordTokenFluent ApplyIncludes(ForgotPasswordTokenInclude include);
}
