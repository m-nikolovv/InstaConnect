using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Responses;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

internal class ChatMessageFluent : IChatMessageFluent
{
	private readonly IChatMessageIncluderFactory _includerFactory;
	private readonly IChatMessageResponseFluentFactory _responseFluentFactory;
	private readonly IMongoDbFluentHandler<ChatMessage, ChatMessageId> _fluentHandler;

	public ChatMessageFluent(
		IChatMessageIncluderFactory includerFactory,
		IChatMessageResponseFluentFactory responseFluentFactory,
		IMongoDbFluentHandler<ChatMessage, ChatMessageId> fluentHandler)
	{
		_fluentHandler = fluentHandler;
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IChatMessageFluent ApplyIncludes(ChatMessageInclude include)
	{
		_fluentHandler.ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IChatMessageFluent Match(ChatMessagesFilterQuery filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IChatMessageFluent Match(ChatMessageId filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IChatMessageFluent Match(IEnumerable<ChatMessageId> filter)
	{
		_fluentHandler.Match(filter.GetFilter());

		return this;
	}

	public IChatMessageResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id.ToLower();
		var projection = Builders<ChatMessage>.Projection.Expression(p =>
			new ChatMessageResponse(
					new ChatMessageId(
						new ChatId(
								   p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantOneId : p.Id.Id.ParticipantTwoId,
								   p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantTwoId : p.Id.Id.ParticipantOneId),
						p.Id.MessageId),
					p.Content,
					p.Summary,
					p.SenderId,
					new ChatResponse(
						new ChatId(
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantOneId : p.Id.Id.ParticipantTwoId,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantTwoId : p.Id.Id.ParticipantOneId),
						new UserResponse(
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.Id : p.Chat!.ParticipantTwo!.Id,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantOne!.FirstName : p.Chat.ParticipantTwo!.FirstName,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantOne!.LastName : p.Chat.ParticipantTwo!.LastName,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantOne!.Email : p.Chat.ParticipantTwo!.Email,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantOne!.Name : p.Chat.ParticipantTwo!.Name,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantOne!.ProfileImageUrl : p.Chat.ParticipantTwo!.ProfileImageUrl,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantOne!.CreatedAtUtc : p.Chat.ParticipantTwo!.CreatedAtUtc,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantOne!.UpdatedAtUtc : p.Chat.ParticipantTwo!.UpdatedAtUtc),
						new UserResponse(
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantTwo!.Id : p.Chat.ParticipantOne!.Id,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantTwo!.FirstName : p.Chat.ParticipantOne!.FirstName,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantTwo!.LastName : p.Chat.ParticipantOne!.LastName,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantTwo!.Email : p.Chat.ParticipantOne!.Email,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantTwo!.Name : p.Chat.ParticipantOne!.Name,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantTwo!.ProfileImageUrl : p.Chat.ParticipantOne!.ProfileImageUrl,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantTwo!.CreatedAtUtc : p.Chat.ParticipantOne!.CreatedAtUtc,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantTwo!.UpdatedAtUtc : p.Chat.ParticipantOne!.UpdatedAtUtc),
						p.Chat.ChatMessages.Count,
						p.Chat.CreatedAtUtc),
					new UserResponse(
						p.Sender!.Id,
						p.Sender.FirstName,
						p.Sender.LastName,
						p.Sender.Email,
						p.Sender.Name,
						p.Sender.ProfileImageUrl,
						p.Sender.CreatedAtUtc,
						p.Sender.UpdatedAtUtc),
					p.ChatMessageImages.Select(
						pi => new ChatMessageImageResponse(
							new ChatMessageImageId(
								new ChatMessageId(
									new ChatId(
										p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? pi.Id.Id.Id.ParticipantOneId : pi.Id.Id.Id.ParticipantTwoId,
										p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? pi.Id.Id.Id.ParticipantTwoId : pi.Id.Id.Id.ParticipantOneId),
									pi.Id.Id.MessageId),
								pi.Id.ImageId),
							pi.Url,
							pi.CreatedAtUtc)).ToList(),
					p.CreatedAtUtc,
					p.UpdatedAtUtc));
		var fluent = _fluentHandler.Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IChatMessageResponseFluent ProjectToResponseWithoutChat(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id.ToLower();
		var projection = Builders<ChatMessage>.Projection.Expression(p =>
			new ChatMessageResponse(
					new ChatMessageId(
						new ChatId(
								   p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantOneId : p.Id.Id.ParticipantTwoId,
								   p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantTwoId : p.Id.Id.ParticipantOneId),
						p.Id.MessageId),
					p.Content,
					p.Summary,
					p.SenderId,
					null,
					new UserResponse(
						p.Sender!.Id,
						p.Sender.FirstName,
						p.Sender.LastName,
						p.Sender.Email,
						p.Sender.Name,
						p.Sender.ProfileImageUrl,
						p.Sender.CreatedAtUtc,
						p.Sender.UpdatedAtUtc),
					p.ChatMessageImages.Select(
						pi => new ChatMessageImageResponse(
							new ChatMessageImageId(
								new ChatMessageId(
									new ChatId(
										p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? pi.Id.Id.Id.ParticipantOneId : pi.Id.Id.Id.ParticipantTwoId,
										p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? pi.Id.Id.Id.ParticipantTwoId : pi.Id.Id.Id.ParticipantOneId),
									pi.Id.Id.MessageId),
								pi.Id.ImageId),
							pi.Url,
							pi.CreatedAtUtc)).ToList(),
					p.CreatedAtUtc,
					p.UpdatedAtUtc));
		var fluent = _fluentHandler.Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IChatMessageResponseFluent ProjectToResponseWithoutSender(CurrentUserQuery currentUser)
	{
		var currentUserId = currentUser.Id.Id.ToLower();
		var projection = Builders<ChatMessage>.Projection.Expression(p =>
			new ChatMessageResponse(
					new ChatMessageId(
						new ChatId(
								   p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantOneId : p.Id.Id.ParticipantTwoId,
								   p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantTwoId : p.Id.Id.ParticipantOneId),
						p.Id.MessageId),
					p.Content,
					p.Summary,
					p.SenderId,
					new ChatResponse(
						new ChatId(
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantOneId : p.Id.Id.ParticipantTwoId,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantTwoId : p.Id.Id.ParticipantOneId),
						new UserResponse(
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.Id : p.Chat!.ParticipantTwo!.Id,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantOne!.FirstName : p.Chat.ParticipantTwo!.FirstName,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantOne!.LastName : p.Chat.ParticipantTwo!.LastName,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantOne!.Email : p.Chat.ParticipantTwo!.Email,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantOne!.Name : p.Chat.ParticipantTwo!.Name,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantOne!.ProfileImageUrl : p.Chat.ParticipantTwo!.ProfileImageUrl,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantOne!.CreatedAtUtc : p.Chat.ParticipantTwo!.CreatedAtUtc,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantOne!.UpdatedAtUtc : p.Chat.ParticipantTwo!.UpdatedAtUtc),
						new UserResponse(
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantTwo!.Id : p.Chat.ParticipantOne!.Id,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantTwo!.FirstName : p.Chat.ParticipantOne!.FirstName,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantTwo!.LastName : p.Chat.ParticipantOne!.LastName,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantTwo!.Email : p.Chat.ParticipantOne!.Email,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantTwo!.Name : p.Chat.ParticipantOne!.Name,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantTwo!.ProfileImageUrl : p.Chat.ParticipantOne!.ProfileImageUrl,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantTwo!.CreatedAtUtc : p.Chat.ParticipantOne!.CreatedAtUtc,
							p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat.ParticipantTwo!.UpdatedAtUtc : p.Chat.ParticipantOne!.UpdatedAtUtc),
						p.Chat.ChatMessages.Count,
						p.CreatedAtUtc),
					null,
					p.ChatMessageImages.Select(
						pi => new ChatMessageImageResponse(
							new ChatMessageImageId(
								new ChatMessageId(
									new ChatId(
										p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? pi.Id.Id.Id.ParticipantOneId : pi.Id.Id.Id.ParticipantTwoId,
										p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? pi.Id.Id.Id.ParticipantTwoId : pi.Id.Id.Id.ParticipantOneId),
									pi.Id.Id.MessageId),
								pi.Id.ImageId),
							pi.Url,
							pi.CreatedAtUtc)).ToList(),
					p.CreatedAtUtc,
					p.UpdatedAtUtc));
		var fluent = _fluentHandler.Project(projection);

		return _responseFluentFactory.Create(fluent);
	}

	public IMongoDbFluent<ChatMessage, ChatMessageId> Match(FilterDefinition<ChatMessage> filterDefinition)
	{
		_fluentHandler.Match(filterDefinition);

		return this;
	}

	public async Task<ChatMessage?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<long> GetCountAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetCountAsync(cancellationToken);
	}

	public async Task<ICollection<ChatMessage>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}

	public async Task<bool> AnyAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.AnyAsync(cancellationToken);
	}

	public async Task<ICollection<ChatMessageId>> GetIdsAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.GetIdsAsync(cancellationToken);
	}
}
