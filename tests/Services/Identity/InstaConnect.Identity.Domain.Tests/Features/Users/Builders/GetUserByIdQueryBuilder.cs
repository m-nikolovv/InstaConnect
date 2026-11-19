namespace InstaConnect.Identity.Domain.Tests.Features.Users.Builders;

public class GetUserByIdQueryBuilder
{
	private string _id;
	private string _currentUserId;

	public GetUserByIdQueryBuilder(User user, UserId currentUserId)
	{
		_id = user.Id.Id;
		_currentUserId = currentUserId.Id;
	}

	public GetUserByIdQueryBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetUserByIdQueryBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetUserByIdQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetUserByIdQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetUserByIdQuery Build()
	{
		return new(
			new(_id),
			new(new(_currentUserId)));
	}
}
