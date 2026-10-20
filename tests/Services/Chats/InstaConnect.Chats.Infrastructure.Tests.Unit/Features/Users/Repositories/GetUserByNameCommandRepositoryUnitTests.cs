using InstaConnect.Chats.Domain.Features.Users.Models.Entities;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Infrastructure.Tests.Features.Builders;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Users.Repositories;

public class GetUserByNameCommandRepositoryUnitTests : BaseUserInfrastructureCommandUnitTest
{
	private readonly NameBuilderFactory _nameBuilderFactory;
	private readonly NameBuilder _nameBuilder;
	private readonly Name _name;

	private readonly UserInclude _include;

	private readonly UserCommandRepository _repository;

	public GetUserByNameCommandRepositoryUnitTests()
	{
		_nameBuilderFactory = new();
		_nameBuilder = _nameBuilderFactory.Create(User.Name);
		_name = _nameBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithChats().WithChatMessages().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_name, Fluent);
		Fluent.SetupApplyIncludes(_name, _include);
		Fluent.SetupMatch(_name);
		Fluent.SetupFirstOrDefaultAsync(_name, User, CancellationToken);
	}

	[Fact]
	public async Task GetByNameAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByNameAsync(_name, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(_name, User);
	}

	[Fact]
	public async Task GetByNameAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByNameAsync(_name, _include, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_name);
	}

	[Fact]
	public async Task GetByNameAsync_ShouldCallTheFluentApplyIncludes_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByNameAsync(_name, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(_name, _include);
	}

	[Fact]
	public async Task GetByNameAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByNameAsync(_name, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_name);
	}

	[Fact]
	public async Task GetByNameAsync_ShouldCallTheFluentFirstOrDefaultAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByNameAsync(_name, _include, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(_name, CancellationToken);
	}
}
