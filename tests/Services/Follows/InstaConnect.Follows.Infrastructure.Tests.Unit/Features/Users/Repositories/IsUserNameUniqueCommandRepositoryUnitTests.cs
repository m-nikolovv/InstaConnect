using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Infrastructure.Tests.Features.Builders;
using InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Repositories;

namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Users.Repositories;

public class IsUserNameUniqueCommandRepositoryUnitTests : BaseUserInfrastructureCommandUnitTest
{
	private readonly NameBuilderFactory _nameBuilderFactory;
	private readonly NameBuilder _nameBuilder;
	private readonly Name _name;

	private readonly UserCommandRepository _repository;

	public IsUserNameUniqueCommandRepositoryUnitTests()
	{
		_nameBuilderFactory = new();
		_nameBuilder = _nameBuilderFactory.Create(User.Name);
		_name = _nameBuilder.Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_name, Fluent);
		Fluent.SetupMatch(_name);
		Fluent.SetupAnyAsync(_name, User, CancellationToken);
	}

	[Fact]
	public async Task IsNameUniqueAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.IsNameUniqueAsync(_name, CancellationToken);

		// Assert
		response.ShouldSatisfy(_name, User);
	}

	[Fact]
	public async Task IsNameUniqueAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.IsNameUniqueAsync(_name, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_name);
	}

	[Fact]
	public async Task IsNameUniqueAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.IsNameUniqueAsync(_name, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_name);
	}

	[Fact]
	public async Task IsNameUniqueAsync_ShouldCallTheFluentAnyAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.IsNameUniqueAsync(_name, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(_name, CancellationToken);
	}
}
