using InstaConnect.Chats.Domain.Features.Users.Models.Responses;
using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Collections;

internal class ChatFluent : MongoDbFluent<Chat>, IChatFluent
{
	private readonly IChatIncluderFactory _includerFactory;
	private readonly IChatResponseFluentFactory _responseFluentFactory;

	public ChatFluent(
		IAggregateFluent<Chat> fluent,
		IChatIncluderFactory includerFactory,
		IChatResponseFluentFactory responseFluentFactory) : base(fluent)
	{
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IChatFluent ApplyIncludes(ChatInclude include)
	{
		ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IChatFluent Match(ChatsFilterQuery filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IChatFluent Match(ChatId filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IChatResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id.ToLower();
		var projection = Builders<Chat>.Projection.Expression(p =>
				   new ChatResponse(
							   new ChatId(
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.ParticipantOneId : p.Id.ParticipantTwoId,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.ParticipantTwoId : p.Id.ParticipantOneId),
							   new UserResponse(
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.Id : p.ParticipantTwo!.Id,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.FirstName : p.ParticipantTwo!.FirstName,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.LastName : p.ParticipantTwo!.LastName,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.Email : p.ParticipantTwo!.Email,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.Name : p.ParticipantTwo!.Name,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.ProfileImageUrl : p.ParticipantTwo!.ProfileImageUrl,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.CreatedAtUtc : p.ParticipantTwo!.CreatedAtUtc,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.UpdatedAtUtc : p.ParticipantTwo!.UpdatedAtUtc),
							   new UserResponse(
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.Id : p.ParticipantOne!.Id,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.FirstName : p.ParticipantOne!.FirstName,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.LastName : p.ParticipantOne!.LastName,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.Email : p.ParticipantOne!.Email,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.Name : p.ParticipantOne!.Name,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.ProfileImageUrl : p.ParticipantOne!.ProfileImageUrl,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.CreatedAtUtc : p.ParticipantOne!.CreatedAtUtc,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.UpdatedAtUtc : p.ParticipantOne!.UpdatedAtUtc),
							   p.CreatedAtUtc));
		var fluent = Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IChatResponseFluent ProjectToResponseWithoutParticipantOne(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id.ToLower();
		var projection = Builders<Chat>.Projection.Expression(p =>
				   new ChatResponse(
							   new ChatId(
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.ParticipantOneId : p.Id.ParticipantTwoId,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.ParticipantTwoId : p.Id.ParticipantOneId),
							   null,
							   new UserResponse(
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.Id : p.ParticipantOne!.Id,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.FirstName : p.ParticipantOne!.FirstName,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.LastName : p.ParticipantOne!.LastName,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.Email : p.ParticipantOne!.Email,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.Name : p.ParticipantOne!.Name,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.ProfileImageUrl : p.ParticipantOne!.ProfileImageUrl,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.CreatedAtUtc : p.ParticipantOne!.CreatedAtUtc,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.UpdatedAtUtc : p.ParticipantOne!.UpdatedAtUtc),
							   p.CreatedAtUtc));
		var fluent = Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IChatResponseFluent ProjectToResponseWithoutParticipantTwo(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id.ToLower();
		var projection = Builders<Chat>.Projection.Expression(p =>
				   new ChatResponse(
							   new ChatId(
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.ParticipantOneId : p.Id.ParticipantTwoId,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.ParticipantTwoId : p.Id.ParticipantOneId),
							   new UserResponse(
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.Id : p.ParticipantTwo!.Id,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.FirstName : p.ParticipantTwo!.FirstName,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.LastName : p.ParticipantTwo!.LastName,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.Email : p.ParticipantTwo!.Email,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.Name : p.ParticipantTwo!.Name,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.ProfileImageUrl : p.ParticipantTwo!.ProfileImageUrl,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.CreatedAtUtc : p.ParticipantTwo!.CreatedAtUtc,
								   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.UpdatedAtUtc : p.ParticipantTwo!.UpdatedAtUtc),
							   null,
							   p.CreatedAtUtc));
		var fluent = Project(projection);

		return _responseFluentFactory.Create(fluent);
	}
}
