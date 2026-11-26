using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Collections;

internal class ForgotPasswordTokenFluentFactory : IForgotPasswordTokenFluentFactory
{
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;
	private readonly IForgotPasswordTokenIncluderFactory _includerFactory;

	public ForgotPasswordTokenFluentFactory(
		IMongoDbFluentHandlerFactory fluentHandlerFactory,
		IForgotPasswordTokenIncluderFactory includerFactory)
	{
		_includerFactory = includerFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
	}

	public IForgotPasswordTokenFluent Create(IAggregateFluent<ForgotPasswordToken> fluent)
	{
		return new ForgotPasswordTokenFluent(_includerFactory, _fluentHandlerFactory.Create<ForgotPasswordToken, ForgotPasswordTokenId>(fluent));
	}
}
