namespace InstaConnect.Posts.Infrastructure.Tests.Features.Common.Builders;

public class CurrentUserQueryBuilder
{
	private string _currentUserId;

	public CurrentUserQueryBuilder(User user)
	{
		_currentUserId = user.Id.Id;
	}

	public CurrentUserQueryBuilder WithCurrentUserId(IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(_currentUserId);

		return this;
	}

	public CurrentUserQuery Build()
	{
		return new(new(_currentUserId));
	}
}
