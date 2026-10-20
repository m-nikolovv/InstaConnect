namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenFluentFactory
{
	public IForgotPasswordTokenFluent Create(IAggregateFluent<ForgotPasswordToken> fluent);
}
