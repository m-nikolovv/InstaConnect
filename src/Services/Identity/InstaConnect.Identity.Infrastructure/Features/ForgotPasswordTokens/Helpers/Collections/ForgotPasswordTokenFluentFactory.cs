namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Collections;

internal class ForgotPasswordTokenFluentFactory : IForgotPasswordTokenFluentFactory
{
	private readonly IForgotPasswordTokenIncluderFactory _includerFactory;

	public ForgotPasswordTokenFluentFactory(IForgotPasswordTokenIncluderFactory includerFactory)
	{
		_includerFactory = includerFactory;
	}

	public IForgotPasswordTokenFluent Create(IAggregateFluent<ForgotPasswordToken> fluent)
	{
		return new ForgotPasswordTokenFluent(fluent, _includerFactory);
	}
}
