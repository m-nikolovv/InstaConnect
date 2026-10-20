using InstaConnect.Follows.Tests.Features.Follows.Assertions;

namespace InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Factories;

public class CreateFollowFactoryUnitTests : BaseFollowDomainCommandUnitTest
{
	private readonly FollowFactory _factory;

	public CreateFollowFactoryUnitTests()
	{
		_factory = new(DateTimeProvider);

		DateTimeProvider.SetupGetOffsetUtcNow(Follow);
	}

	[Fact]
	public void Create_ShouldCreateFollow_WhenRequestIsValid()
	{
		// Act
		var response = _factory.Create(FollowId.FollowerId, FollowId.FollowingId);

		// Assert
		response.ShouldSatisfy(Follow);
	}

	[Fact]
	public void Create_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.Create(FollowId.FollowerId, FollowId.FollowingId);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
	}
}
