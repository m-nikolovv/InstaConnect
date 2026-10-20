namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Builders;

public class EmailConfirmationTokenIdBuilder
{
	private string _id;
	private string _value;

	public EmailConfirmationTokenIdBuilder(EmailConfirmationTokenId id)
	{
		_id = id.Id.Id;
		_value = id.Value;
	}

	public EmailConfirmationTokenIdBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public EmailConfirmationTokenIdBuilder WithValue(IStringTransformer transformer)
	{
		_value = transformer.Transform(_value);

		return this;
	}

	public EmailConfirmationTokenId Build()
	{
		return new(new(_id), _value);
	}
}
