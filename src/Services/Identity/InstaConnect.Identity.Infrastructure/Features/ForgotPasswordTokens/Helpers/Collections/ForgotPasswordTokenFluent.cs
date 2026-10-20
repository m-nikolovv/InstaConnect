using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Collections;

internal class ForgotPasswordTokenFluent : MongoDbFluent<ForgotPasswordToken>, IForgotPasswordTokenFluent
{
	private readonly IForgotPasswordTokenIncluderFactory _includerFactory;

	public ForgotPasswordTokenFluent(
		IAggregateFluent<ForgotPasswordToken> fluent,
		IForgotPasswordTokenIncluderFactory includerFactory) : base(fluent)
	{
		_includerFactory = includerFactory;
	}

	public IForgotPasswordTokenFluent ApplyIncludes(ForgotPasswordTokenInclude include)
	{
		ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IForgotPasswordTokenFluent Match(ForgotPasswordTokenId filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IForgotPasswordTokenFluent Match(IEnumerable<ForgotPasswordTokenId> filter)
	{
		Match(filter.GetFilter());

		return this;
	}
}
