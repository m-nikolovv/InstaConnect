using InstaConnect.Chats.Application.Features.ChatMessages.Models;
using InstaConnect.Chats.Application.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Application.Tests.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Entities;
using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Requests;
using InstaConnect.Chats.Domain.Features.Users.Models.Requests;
using InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;
using InstaConnect.Common.Tests.Features.Extensions;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageEquals
{
	extension(ChatMessageAddedNotificationRequest r)
	{
		public bool Matches(AddChatMessageCommandRequest request, ChatMessage entity)
		{
			return r.ChatMessage.Matches(request, entity);
		}

		public bool MatchesInverted(AddChatMessageCommandRequest request, ChatMessage entity)
		{
			return r.ChatMessage.MatchesInverted(request, entity);
		}
	}

	extension(ChatMessageUpdatedNotificationRequest r)
	{
		public bool Matches(UpdateChatMessageCommandRequest request, ChatMessage entity)
		{
			return r.ChatMessage.Matches(request, entity);
		}

		public bool MatchesInverted(UpdateChatMessageCommandRequest request, ChatMessage entity)
		{
			return r.ChatMessage.MatchesInverted(request, entity);
		}
	}

	extension(ChatMessageDeletedNotificationRequest r)
	{
		public bool Matches(DeleteChatMessageCommandRequest request, ChatMessage entity)
		{
			return r.ChatMessage.Matches(request, entity);
		}

		public bool MatchesInverted(DeleteChatMessageCommandRequest request, ChatMessage entity)
		{
			return r.ChatMessage.MatchesInverted(request, entity);
		}
	}

	extension(ChatMessageNotificationRequest r)
	{
		public bool Matches(AddChatMessageCommandRequest request, ChatMessage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(entity.Id.MessageId) &&
				   r.Sender.MatchesSender(request, entity.Sender) &&
				   r.Chat.Matches(request, entity.Chat) &&
				   r.ChatMessageImages.Matches(request, entity.ChatMessageImages) &&
				   r.Content == request.Content &&
				   r.Summary == entity.GetSummary(request) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(UpdateChatMessageCommandRequest request, ChatMessage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(request.MessageId) &&
				   r.Sender.MatchesSender(request, entity.Sender) &&
				   r.Chat.Matches(request, entity.Chat) &&
				   r.ChatMessageImages.Matches(request, entity.ChatMessageImages) &&
				   r.Content == request.Content &&
				   r.Summary == entity.GetSummary(request) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeleteChatMessageCommandRequest request, ChatMessage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(request.MessageId) &&
				   r.Sender.MatchesSender(request, entity.Sender) &&
				   r.Chat.Matches(request, entity.Chat) &&
				   r.ChatMessageImages.Matches(request, entity.ChatMessageImages) &&
				   r.Content == entity.Content &&
				   entity.Summary.Matches(r.Summary) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesInverted(AddChatMessageCommandRequest request, ChatMessage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(entity.Id.MessageId) &&
				   r.Sender.MatchesSenderInverted(request, entity.Sender) &&
				   r.Chat.MatchesInverted(request, entity.Chat) &&
				   r.ChatMessageImages.MatchesInverted(request, entity.ChatMessageImages) &&
				   r.Content == request.Content &&
				   r.Summary == entity.GetSummary(request) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesInverted(UpdateChatMessageCommandRequest request, ChatMessage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(request.MessageId) &&
				   r.Sender.MatchesSenderInverted(request, entity.Sender) &&
				   r.Chat.MatchesInverted(request, entity.Chat) &&
				   r.ChatMessageImages.MatchesInverted(request, entity.ChatMessageImages) &&
				   r.Content == request.Content &&
				   r.Summary == entity.GetSummary(request) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesInverted(DeleteChatMessageCommandRequest request, ChatMessage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(request.MessageId) &&
				   r.Sender.MatchesSenderInverted(request, entity.Sender) &&
				   r.Chat.MatchesInverted(request, entity.Chat) &&
				   r.ChatMessageImages.MatchesInverted(request, entity.ChatMessageImages) &&
				   r.Content == entity.Content &&
				   entity.Summary.Matches(r.Summary) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(ChatMessageImageNotificationRequest r)
	{
		public bool Matches(AddChatMessageCommandRequest request, ChatMessageImage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(entity.Id.Id.MessageId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   request.Images.ContainsUrl(r.Url) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(UpdateChatMessageCommandRequest request, ChatMessageImage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(request.MessageId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeleteChatMessageCommandRequest request, ChatMessageImage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(request.MessageId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(AddChatMessageCommandRequest request, ChatMessageImage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(entity.Id.Id.MessageId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   request.Images.ContainsUrl(r.Url) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(UpdateChatMessageCommandRequest request, ChatMessageImage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(request.MessageId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(DeleteChatMessageCommandRequest request, ChatMessageImage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(request.MessageId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(ICollection<ChatMessageImageNotificationRequest> r)
	{
		public bool Matches(AddChatMessageCommandRequest request, ICollection<ChatMessageImage> entities)
		{
			return r.MatchesCollectionAndEmpty(
				entities,
				response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
				chatMessageImage => chatMessageImage.Id,
				(r, chatMessageImage) => r.Matches(request, chatMessageImage));
		}

		public bool Matches(UpdateChatMessageCommandRequest request, ICollection<ChatMessageImage> entities)
		{
			return r.MatchesCollectionAndNotEmpty(
				entities,
				response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
				chatMessageImage => chatMessageImage.Id,
				(r, chatMessageImage) => r.Matches(request, chatMessageImage));
		}

		public bool Matches(DeleteChatMessageCommandRequest request, ICollection<ChatMessageImage> entities)
		{
			return r.MatchesCollectionAndNotEmpty(
				entities,
				response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
				chatMessageImage => chatMessageImage.Id,
				(r, chatMessageImage) => r.Matches(request, chatMessageImage));
		}

		public bool MatchesInverted(AddChatMessageCommandRequest request, ICollection<ChatMessageImage> entities)
		{
			return r.MatchesCollectionAndEmpty(
				entities,
				response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
				chatMessageImage => chatMessageImage.Id,
				(r, chatMessageImage) => r.MatchesInverted(request, chatMessageImage));
		}

		public bool MatchesInverted(UpdateChatMessageCommandRequest request, ICollection<ChatMessageImage> entities)
		{
			return r.MatchesCollectionAndNotEmpty(
				entities,
				response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
				chatMessageImage => chatMessageImage.Id,
				(r, chatMessageImage) => r.MatchesInverted(request, chatMessageImage));
		}

		public bool MatchesInverted(DeleteChatMessageCommandRequest request, ICollection<ChatMessageImage> entities)
		{
			return r.MatchesCollectionAndNotEmpty(
				entities,
				response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
				chatMessageImage => chatMessageImage.Id,
				(r, chatMessageImage) => r.MatchesInverted(request, chatMessageImage));
		}
	}

	extension(ChatNotificationRequest r)
	{
		public bool Matches(AddChatMessageCommandRequest request, Chat? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantOne.MatchesParticipantOne(request, entity.ParticipantOne) &&
				   r.ParticipantTwo.MatchesParticipantTwo(request, entity.ParticipantTwo) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(UpdateChatMessageCommandRequest request, Chat? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantOne.MatchesParticipantOne(request, entity.ParticipantOne) &&
				   r.ParticipantTwo.MatchesParticipantTwo(request, entity.ParticipantTwo) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeleteChatMessageCommandRequest request, Chat? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantOne.MatchesParticipantOne(request, entity.ParticipantOne) &&
				   r.ParticipantTwo.MatchesParticipantTwo(request, entity.ParticipantTwo) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(AddChatMessageCommandRequest request, Chat? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantOne.MatchesParticipantTwo(request, entity.ParticipantOne) &&
				   r.ParticipantTwo.MatchesParticipantOne(request, entity.ParticipantTwo) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(UpdateChatMessageCommandRequest request, Chat? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantOne.MatchesParticipantTwo(request, entity.ParticipantOne) &&
				   r.ParticipantTwo.MatchesParticipantOne(request, entity.ParticipantTwo) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(DeleteChatMessageCommandRequest request, Chat? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantOne.MatchesParticipantTwo(request, entity.ParticipantOne) &&
				   r.ParticipantTwo.MatchesParticipantOne(request, entity.ParticipantTwo) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(UserNotificationRequest r)
	{
		public bool MatchesSender(AddChatMessageCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesSender(UpdateChatMessageCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesSender(DeleteChatMessageCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesSenderInverted(AddChatMessageCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesSenderInverted(UpdateChatMessageCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesSenderInverted(DeleteChatMessageCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesParticipantOne(AddChatMessageCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesParticipantOne(UpdateChatMessageCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesParticipantOne(DeleteChatMessageCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesParticipantTwo(AddChatMessageCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesParticipantTwo(UpdateChatMessageCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesParticipantTwo(DeleteChatMessageCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(GetAllChatMessagesQuery query)
	{
		public bool Matches(GetAllChatMessagesQueryRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllChatMessagesQuery, ChatMessagesSortTerm, ChatMessagesSortingQuery, GetAllChatMessagesQueryRequest>(request) &&
				   query.MatchesPaginatable<GetAllChatMessagesQuery, ChatMessagesPaginationQuery, GetAllChatMessagesQueryRequest>(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllChatMessagesQueryRequest request)
		{
			return query.Filter.Id.Matches(request.CurrentUserId, request.ParticipantTwoId);
		}
	}

	extension(GetChatMessageByIdQuery query)
	{
		public bool Matches(GetChatMessageByIdQueryRequest request)
		{
			return query.Id.Matches(request.CurrentUserId, request.ParticipantTwoId, request.MessageId) &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddChatMessageCommand command)
	{
		public bool Matches(AddChatMessageCommandRequest request)
		{
			return command.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId) &&
				   command.Content == request.Content &&
				   command.Images == request.Images;
		}
	}

	extension(UpdateChatMessageCommand command)
	{
		public bool Matches(UpdateChatMessageCommandRequest request)
		{
			return command.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId, request.MessageId) &&
				   command.Content == request.Content;
		}
	}

	extension(DeleteChatMessageCommand command)
	{
		public bool Matches(DeleteChatMessageCommandRequest request)
		{
			return command.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId, request.MessageId);
		}
	}

	extension(AddChatMessageCommandResponse response)
	{
		public bool Matches(AddChatMessageCommandRequest request, ChatMessage chatMessage)
		{
			return response.Response.Matches(chatMessage.Id);
		}
	}

	extension(UpdateChatMessageCommandResponse response)
	{
		public bool Matches(UpdateChatMessageCommandRequest request, ChatMessage chatMessage)
		{
			return response.Response.Matches(chatMessage.Id);
		}
	}

	extension(GetChatMessageByIdQueryResponse response)
	{
		public bool Matches(GetChatMessageByIdQueryRequest request, ChatMessage chatMessage)
		{
			return response.Response.MatchesFull(request, chatMessage);
		}

		public bool MatchesInverted(GetChatMessageByIdQueryRequest request, ChatMessage chatMessage)
		{
			return response.Response.MatchesFullInverted(request, chatMessage);
		}
	}

	extension(GetAllChatMessagesQueryResponse response)
	{
		public bool Matches(GetAllChatMessagesQueryRequest request, Chat chat, ICollection<ChatMessage> chatMessages)
		{
			return response.Response.MatchesWithoutSender(
				request,
				(response, message) => response.MatchesWithoutChat(request, message),
				message => message.MatchesFilter(request),
				chat,
				chatMessages);
		}

		public bool Matches(GetAllChatMessagesQueryRequest request, Chat chat, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			return response.Response.MatchesWithoutSender(
				request,
				(response, message) => response.MatchesWithoutChat(request, message),
				message => message.MatchesFilter(request),
				chat,
				chatMessages,
				termTransformer);
		}

		public bool MatchesInverted(GetAllChatMessagesQueryRequest request, Chat chat, ICollection<ChatMessage> chatMessages)
		{
			return response.Response.MatchesWithoutSenderInverted(
				request,
				(response, message) => response.MatchesWithoutChatInverted(request, message),
				message => message.MatchesFilter(request),
				chat,
				chatMessages);
		}

		public bool MatchesInverted(GetAllChatMessagesQueryRequest request, Chat chat, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			return response.Response.MatchesWithoutSenderInverted(
				request,
				(response, message) => response.MatchesWithoutChatInverted(request, message),
				message => message.MatchesFilter(request),
				chat,
				chatMessages,
				termTransformer);
		}
	}

	extension(ChatMessage chatMessage)
	{
		public bool Matches(AddChatMessageCommandRequest request)
		{
			return chatMessage.Id.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId) &&
				   chatMessage.Id.MessageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   chatMessage.SenderId.Matches(request.ParticipantOneId) &&
				   chatMessage.Content == request.Content &&
				   chatMessage.Summary.Matches(chatMessage.GetSummary(request)) &&
				   chatMessage.CreatedAtUtc != default &&
				   chatMessage.UpdatedAtUtc != default;
		}

		public bool Matches(UpdateChatMessageCommandRequest request)
		{
			return chatMessage.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId, request.MessageId) &&
				   chatMessage.SenderId.Matches(request.ParticipantOneId) &&
				   chatMessage.Content == request.Content &&
				   chatMessage.Summary.Matches(chatMessage.GetSummary(request)) &&
				   chatMessage.CreatedAtUtc != default &&
				   chatMessage.UpdatedAtUtc != default;
		}

		public bool MatchesInverted(AddChatMessageCommandRequest request)
		{
			return chatMessage.Id.Id.Matches(request.ParticipantTwoId, request.ParticipantOneId) &&
				   chatMessage.Id.MessageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   chatMessage.SenderId.Matches(request.ParticipantTwoId) &&
				   chatMessage.Content == request.Content &&
				   chatMessage.Summary.Matches(chatMessage.GetSummary(request)) &&
				   chatMessage.CreatedAtUtc != default &&
				   chatMessage.UpdatedAtUtc != default;
		}

		public bool MatchesInverted(UpdateChatMessageCommandRequest request)
		{
			return chatMessage.Id.Matches(request.ParticipantTwoId, request.ParticipantOneId, request.MessageId) &&
				   chatMessage.SenderId.Matches(request.ParticipantOneId) &&
				   chatMessage.Content == request.Content &&
				   chatMessage.Summary.Matches(chatMessage.GetSummary(request)) &&
				   chatMessage.CreatedAtUtc != default &&
				   chatMessage.UpdatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllChatMessagesQueryRequest request)
		{
			return (chatMessage.Id.Id.ParticipantOneId.Matches(request.CurrentUserId) &&
				   chatMessage.Id.Id.ParticipantTwoId.Matches(request.ParticipantTwoId)) ||
				   (chatMessage.Id.Id.ParticipantOneId.Matches(request.ParticipantTwoId) &&
				   chatMessage.Id.Id.ParticipantTwoId.Matches(request.CurrentUserId));
		}
	}

	extension(ChatMessageImage chatMessageImage)
	{
		public bool Matches(AddChatMessageCommandRequest request)
		{
			return chatMessageImage.Id.Id.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId) &&
				   chatMessageImage.Id.Id.MessageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   chatMessageImage.Id.ImageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   request.Images.ContainsUrl(chatMessageImage.Url) &&
				   chatMessageImage.CreatedAtUtc != default;
		}

		public bool MatchesInverted(AddChatMessageCommandRequest request)
		{
			return chatMessageImage.Id.Id.Id.Matches(request.ParticipantTwoId, request.ParticipantOneId) &&
				   chatMessageImage.Id.Id.MessageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   chatMessageImage.Id.ImageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   request.Images.ContainsUrl(chatMessageImage.Url) &&
				   chatMessageImage.CreatedAtUtc != default;
		}
	}

	extension(ICollection<ChatMessageImage> chatMessageImages)
	{
		public bool Matches(AddChatMessageCommandRequest request)
		{
			return chatMessageImages.AllAndEmpty(request.Images, chatMessageImage => chatMessageImage.Matches(request));
		}

		public bool MatchesInverted(AddChatMessageCommandRequest request)
		{
			return chatMessageImages.AllAndEmpty(request.Images, chatMessageImage => chatMessageImage.MatchesInverted(request));
		}
	}

	extension(ChatMessageIdCommandResponse response)
	{
		public bool Matches(ChatMessageId id)
		{
			return id.Matches(response.ParticipantOneId, response.ParticipantTwoId, response.MessageId);
		}
	}

	extension(ChatMessageQueryResponse? response)
	{
		public bool MatchesFull<TRequest>(TRequest request, ChatMessage? chatMessage)
		where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId, response.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFull(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat.MatchesFull(request, chatMessage.Chat);
		}

		public bool MatchesWithoutSender<TRequest>(TRequest request, ChatMessage? chatMessage)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId, response.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFull(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender == null &&
				   response.Chat.MatchesFull(request, chatMessage.Chat);
		}

		public bool MatchesWithoutChat<TRequest>(TRequest request, ChatMessage? chatMessage)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId, response.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFull(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat == null;
		}

		public bool MatchesFullInverted<TRequest>(TRequest request, ChatMessage? chatMessage)
		where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId, response.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFullInverted(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat.MatchesFullInverted(request, chatMessage.Chat);
		}

		public bool MatchesWithoutSenderInverted<TRequest>(TRequest request, ChatMessage? chatMessage)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId, response.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFullInverted(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender == null &&
				   response.Chat.MatchesFullInverted(request, chatMessage.Chat);
		}

		public bool MatchesWithoutChatInverted<TRequest>(TRequest request, ChatMessage? chatMessage)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId, response.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFullInverted(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat == null;
		}
	}

	extension(ChatMessageCollectionQueryResponse response)
	{
		public bool MatchesWithoutSender<TRequest>(TRequest request, Func<ChatMessageQueryResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFull(request, chat) &&
				   response.ChatMessages.MatchesCollectionAndNotEmpty(
					   request,
					   chatMessages,
					   response => new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId),
					   chatMessage => chatMessage.Id,
					   matches,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutSender<TRequest>(TRequest request, Func<ChatMessageQueryResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFull(request, chat) &&
				   response.ChatMessages.MatchesSortedCollection(
					   request,
					   chatMessages,
					   matches,
					   termTransformer,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutChat<TRequest>(TRequest request, Func<ChatMessageQueryResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender.MatchesFull(user) &&
				   response.Chat == null &&
				   response.ChatMessages.MatchesCollectionAndNotEmpty(
					   request,
					   chatMessages,
					   response => new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId),
					   chatMessage => chatMessage.Id,
					   matches,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutChat<TRequest>(TRequest request, Func<ChatMessageQueryResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender.MatchesFull(user) &&
				   response.Chat == null &&
				   response.ChatMessages.MatchesSortedCollection(
					   request,
					   chatMessages,
					   matches,
					   termTransformer,
					   matchesFilter
				   );
		}
		public bool MatchesWithoutSenderInverted<TRequest>(TRequest request, Func<ChatMessageQueryResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFullInverted(request, chat) &&
				   response.ChatMessages.MatchesCollectionAndNotEmpty(
					   request,
					   chatMessages,
					   response => new(new(new(response.ParticipantTwoId), new(response.ParticipantOneId)), response.MessageId),
					   chatMessage => chatMessage.Id,
					   matches,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutSenderInverted<TRequest>(TRequest request, Func<ChatMessageQueryResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFullInverted(request, chat) &&
				   response.ChatMessages.MatchesSortedCollection(
					   request,
					   chatMessages,
					   matches,
					   termTransformer,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutChatInverted<TRequest>(TRequest request, Func<ChatMessageQueryResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender.MatchesFull(user) &&
				   response.Chat == null &&
				   response.ChatMessages.MatchesCollectionAndNotEmpty(
					   request,
					   chatMessages,
					   response => new(new(new(response.ParticipantTwoId), new(response.ParticipantOneId)), response.MessageId),
					   chatMessage => chatMessage.Id,
					   matches,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutChatInverted<TRequest>(TRequest request, Func<ChatMessageQueryResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender.MatchesFull(user) &&
				   response.Chat == null &&
				   response.ChatMessages.MatchesSortedCollection(
					   request,
					   chatMessages,
					   matches,
					   termTransformer,
					   matchesFilter
				   );
		}
	}
}
