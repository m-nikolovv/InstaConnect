using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Application.Tests.Features.Assertions;
using InstaConnect.Posts.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
	extension(IUserCollection collection)
	{
		public void ShouldHaveReceivedOneAggregateFluent(UserId id)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			UserId id,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(Name name)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(Email email)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent()
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().UpdateAsync(user, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteAsync(user, cancellationToken);
		}
	}

	extension(IUserFluent fluent)
	{
		public void ShouldHaveReceivedOneMatch(UserId id)
		{
			fluent.ShouldHaveReceivedOne().Match(id);
		}

		public void ShouldHaveReceivedOneMatch(
			UserId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(id);
		}

		public void ShouldHaveReceivedOneMatch(Name name)
		{
			fluent.ShouldHaveReceivedOne().Match(name);
		}

		public void ShouldHaveReceivedOneMatch(Email email)
		{
			fluent.ShouldHaveReceivedOne().Match(email);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			UserId id,
			UserInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			Name name,
			UserInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			Email email,
			UserInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(UserInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(
			UserId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToFullResponse(currentUserQuery);
		}

		public async Task ShouldHaveReceivedOneAnyAsync(
			UserId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneAnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAnyAsync(
			Name name,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneAnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAnyAsync(
			Email email,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneAnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			UserId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			Name name,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			Email email,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}
	}

	extension(IUserResponseFluent fluent)
	{
		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			UserId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}
	}

	extension(IApplicationSender sender)
	{
		public async Task ShouldHaveReceivedOneSendAsync(
		UserAddedEventRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsAddUserCommandRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			UserUpdatedEventRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsUpdateUserCommandRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			UserDeletedEventRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsDeleteUserCommandRequest(), cancellationToken);
		}
	}
}
