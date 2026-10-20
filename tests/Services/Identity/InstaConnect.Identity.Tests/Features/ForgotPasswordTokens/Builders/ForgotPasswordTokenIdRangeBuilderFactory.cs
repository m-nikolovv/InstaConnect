namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;

public class ForgotPasswordTokenIdRangeBuilderFactory
{
	private readonly ForgotPasswordTokenIdBuilderFactory _idBuilderFactory;

	public ForgotPasswordTokenIdRangeBuilderFactory()
	{
		_idBuilderFactory = new();
	}

	public ForgotPasswordTokenIdRangeBuilder Create(ICollection<ForgotPasswordTokenId> ids)
	{
		return new([.. ids.Select(_idBuilderFactory.Create)]);
	}
}
