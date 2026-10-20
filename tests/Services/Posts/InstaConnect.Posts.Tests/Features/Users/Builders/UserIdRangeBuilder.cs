namespace InstaConnect.Posts.Tests.Features.Users.Builders;

public class UserIdRangeBuilder
{
	private readonly ICollection<UserIdBuilder> _idBuilders;

	public UserIdRangeBuilder(ICollection<UserIdBuilder> idBuilders)
	{
		_idBuilders = idBuilders;
	}

	public UserIdRangeBuilder WithId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithId(transformer);
		}

		return this;
	}

	public ICollection<UserId> Build()
	{
		return [.. _idBuilders.Select(idBuilder => idBuilder.Build())];
	}
}
