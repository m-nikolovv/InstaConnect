using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Collections;

internal class ChatFluent : IChatFluent
{
	private readonly IChatIncluderFactory _includerFactory;
	private readonly IChatIncludeBuilderFactory _includeBuilderFactory;
	private readonly IChatResponseFluentFactory _responseFluentFactory;
	private readonly IMongoDbFluentHandler<Chat, ChatId> _fluentHandler;

	public ChatFluent(
		IChatIncluderFactory includerFactory,
		IChatIncludeBuilderFactory includeBuilderFactory,
		IChatResponseFluentFactory responseFluentFactory,
		IMongoDbFluentHandler<Chat, ChatId> fluentHandler)
	{
		_fluentHandler = fluentHandler;
		_includerFactory = includerFactory;
		_includeBuilderFactory = includeBuilderFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IChatFluent ApplyIncludes(ChatInclude include)
	{
		_fluentHandler.ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IChatFluent Match(ChatsFilterQuery filter)
	{
		_fluentHandler.Match(filter.GetParticipantFilter());

		ApplyIncludes(_includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build());
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IChatFluent Match(ChatId filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IChatFluent Match(IEnumerable<ChatId> filter)
	{
		_fluentHandler.Match(filter.GetFilter());

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
							   p.ChatMessages.Count,
							   p.CreatedAtUtc));
		var fluent = _fluentHandler.Project(projection);

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
							   p.ChatMessages.Count,
							   p.CreatedAtUtc));
		var fluent = _fluentHandler.Project(projection);

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
							   p.ChatMessages.Count,
							   p.CreatedAtUtc));
		var fluent = _fluentHandler.Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IMongoDbFluent<Chat, ChatId> Match(FilterDefinition<Chat> filterDefinition)
	{
		_fluentHandler.Match(filterDefinition);

		return this;
	}

	public async Task<Chat?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<long> GetCountAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetCountAsync(cancellationToken);
	}

	public async Task<ICollection<Chat>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}

	public async Task<bool> AnyAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.AnyAsync(cancellationToken);
	}

	public async Task<ICollection<ChatId>> GetIdsAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetIdsAsync(cancellationToken);
	}
}
