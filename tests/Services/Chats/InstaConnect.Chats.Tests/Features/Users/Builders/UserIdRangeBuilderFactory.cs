using InstaConnect.Chats.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Chats.Tests.Features.Users.Builders;

public class UserIdRangeBuilderFactory
{
	private readonly UserIdBuilderFactory _idBuilderFactory;

	public UserIdRangeBuilderFactory()
	{
		_idBuilderFactory = new();
	}

	public UserIdRangeBuilder Create(ICollection<UserId> ids)
	{
		return new([.. ids.Select(_idBuilderFactory.Create)]);
	}
}
