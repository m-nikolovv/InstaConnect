namespace InstaConnect.Posts.Tests.Features.Users.Builders;

public class UserIdBuilder
{
	private string _id;

	public UserIdBuilder(UserId id)
	{
		_id = id.Id;
	}

	public UserIdBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public UserIdBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public UserId Build()
	{
		return new(_id);
	}
}
