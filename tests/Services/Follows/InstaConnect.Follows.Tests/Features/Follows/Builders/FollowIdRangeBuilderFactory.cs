namespace InstaConnect.Follows.Tests.Features.Follows.Builders;

public class FollowIdRangeBuilderFactory
{
	private readonly FollowIdBuilderFactory _idBuilderFactory;

	public FollowIdRangeBuilderFactory()
	{
		_idBuilderFactory = new();
	}

	public FollowIdRangeBuilder Create(ICollection<FollowId> ids)
	{
		return new([.. ids.Select(_idBuilderFactory.Create)]);
	}
}
