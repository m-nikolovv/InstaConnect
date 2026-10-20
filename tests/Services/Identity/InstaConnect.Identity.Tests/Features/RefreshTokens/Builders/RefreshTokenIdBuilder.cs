namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;

public class RefreshTokenIdBuilder
{
	private string _id;
	private string _value;

	public RefreshTokenIdBuilder(RefreshTokenId id)
	{
		_id = id.Id.Id;
		_value = id.Value;
	}

	public RefreshTokenIdBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public RefreshTokenIdBuilder WithValue(IStringTransformer transformer)
	{
		_value = transformer.Transform(_value);

		return this;
	}

	public RefreshTokenId Build()
	{
		return new(new(_id), _value);
	}
}
