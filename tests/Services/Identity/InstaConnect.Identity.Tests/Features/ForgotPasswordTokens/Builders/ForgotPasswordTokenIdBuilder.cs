namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;

public class ForgotPasswordTokenIdBuilder
{
	private string _id;
	private string _value;

	public ForgotPasswordTokenIdBuilder(ForgotPasswordTokenId id)
	{
		_id = id.Id.Id;
		_value = id.Value;
	}

	public ForgotPasswordTokenIdBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public ForgotPasswordTokenIdBuilder WithValue(IStringTransformer transformer)
	{
		_value = transformer.Transform(_value);

		return this;
	}

	public ForgotPasswordTokenId Build()
	{
		return new(new(_id), _value);
	}
}
