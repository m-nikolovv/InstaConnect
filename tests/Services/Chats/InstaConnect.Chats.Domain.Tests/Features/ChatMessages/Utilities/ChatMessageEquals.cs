using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.Extensions;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageEquals
{
	extension(ChatMessageId response)
	{
		public bool Matches(
			AddChatMessageCommand command,
			ChatMessage chatMessage)
		{
			return response.Matches(chatMessage.Id);
		}

		public bool Matches(
			UpdateChatMessageCommand command,
			ChatMessage chatMessage)
		{
			return response.Matches(chatMessage.Id);
		}
	}

	extension(ChatMessageAddedNotificationRequest request)
	{
		public bool Matches(AddChatMessageCommand command, ChatMessage entity)
		{
			return request.ChatMessage.Matches(command, entity);
		}

		public bool MatchesInverted(AddChatMessageCommand command, ChatMessage entity)
		{
			return request.ChatMessage.MatchesInverted(command, entity);
		}
	}

	extension(ChatMessageUpdatedNotificationRequest request)
	{
		public bool Matches(UpdateChatMessageCommand command, ChatMessage entity)
		{
			return request.ChatMessage.Matches(command, entity);
		}

		public bool MatchesInverted(UpdateChatMessageCommand command, ChatMessage entity)
		{
			return request.ChatMessage.MatchesInverted(command, entity);
		}
	}

	extension(ChatMessageDeletedNotificationRequest request)
	{
		public bool Matches(DeleteChatMessageCommand command, ChatMessage entity)
		{
			return request.ChatMessage.Matches(command, entity);
		}

		public bool MatchesInverted(DeleteChatMessageCommand command, ChatMessage entity)
		{
			return request.ChatMessage.MatchesInverted(command, entity);
		}
	}

	extension(ChatMessageNotificationRequest request)
	{
		public bool Matches(AddChatMessageCommand command, ChatMessage? entity)
		{
			return entity != null &&
				   request.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.ParticipantOneId.Id) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.ParticipantTwoId.Id) &&
				   request.MessageId.EqualsOrdinalIgnoreCase(entity.Id.MessageId) &&
				   request.Sender.MatchesSender(command, entity.Sender) &&
				   request.Chat.Matches(command, entity.Chat) &&
				   request.ChatMessageImages.Matches(command, entity.ChatMessageImages) &&
				   request.Content == command.Content &&
				   request.Summary == entity.GetSummary(command) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(UpdateChatMessageCommand command, ChatMessage? entity)
		{
			return entity != null &&
				   request.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantTwoId.Id) &&
				   request.MessageId.EqualsOrdinalIgnoreCase(command.Id.MessageId) &&
				   request.Sender.MatchesSender(command, entity.Sender) &&
				   request.Chat.Matches(command, entity.Chat) &&
				   request.ChatMessageImages.Matches(command, entity.ChatMessageImages) &&
				   request.Content == command.Content &&
				   request.Summary == entity.GetSummary(command) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeleteChatMessageCommand command, ChatMessage? entity)
		{
			return entity != null &&
				   request.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantTwoId.Id) &&
				   request.MessageId.EqualsOrdinalIgnoreCase(command.Id.MessageId) &&
				   request.Sender.MatchesSender(command, entity.Sender) &&
				   request.Chat.Matches(command, entity.Chat) &&
				   request.ChatMessageImages.Matches(command, entity.ChatMessageImages) &&
				   request.Content == entity.Content &&
				   entity.Summary.Matches(request.Summary) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesInverted(AddChatMessageCommand command, ChatMessage? entity)
		{
			return entity != null &&
				   request.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.ParticipantTwoId.Id) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.ParticipantOneId.Id) &&
				   request.MessageId.EqualsOrdinalIgnoreCase(entity.Id.MessageId) &&
				   request.Sender.MatchesSenderInverted(command, entity.Sender) &&
				   request.Chat.MatchesInverted(command, entity.Chat) &&
				   request.ChatMessageImages.MatchesInverted(command, entity.ChatMessageImages) &&
				   request.Content == command.Content &&
				   request.Summary == entity.GetSummary(command) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesInverted(UpdateChatMessageCommand command, ChatMessage? entity)
		{
			return entity != null &&
				   request.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantTwoId.Id) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   request.MessageId.EqualsOrdinalIgnoreCase(command.Id.MessageId) &&
				   request.Sender.MatchesSenderInverted(command, entity.Sender) &&
				   request.Chat.MatchesInverted(command, entity.Chat) &&
				   request.ChatMessageImages.MatchesInverted(command, entity.ChatMessageImages) &&
				   request.Content == command.Content &&
				   request.Summary == entity.GetSummary(command) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesInverted(DeleteChatMessageCommand command, ChatMessage? entity)
		{
			return entity != null &&
				   request.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantTwoId.Id) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   request.MessageId.EqualsOrdinalIgnoreCase(command.Id.MessageId) &&
				   request.Sender.MatchesSenderInverted(command, entity.Sender) &&
				   request.Chat.MatchesInverted(command, entity.Chat) &&
				   request.ChatMessageImages.MatchesInverted(command, entity.ChatMessageImages) &&
				   request.Content == entity.Content &&
				   entity.Summary.Matches(request.Summary) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(ChatMessageImageNotificationRequest r)
	{
		public bool Matches(AddChatMessageCommand command, ChatMessageImage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.ParticipantOneId.Id) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.ParticipantTwoId.Id) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(entity.Id.Id.MessageId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   command.Images.ContainsUrl(r.Url) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(UpdateChatMessageCommand command, ChatMessageImage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantTwoId.Id) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(command.Id.MessageId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeleteChatMessageCommand command, ChatMessageImage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantTwoId.Id) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(command.Id.MessageId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(AddChatMessageCommand command, ChatMessageImage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.ParticipantTwoId.Id) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.ParticipantOneId.Id) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(entity.Id.Id.MessageId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   command.Images.ContainsUrl(r.Url) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(UpdateChatMessageCommand command, ChatMessageImage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantTwoId.Id) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(command.Id.MessageId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(DeleteChatMessageCommand command, ChatMessageImage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantTwoId.Id) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(command.Id.MessageId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(ICollection<ChatMessageImageNotificationRequest> r)
	{
		public bool Matches(AddChatMessageCommand command, ICollection<ChatMessageImage> entities)
		{
			return command.Images.IsEmpty() ||
				   r.MatchesCollection(
					   entities,
					   response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
					   chatMessageImage => chatMessageImage.Id,
					   (r, chatMessageImage) => r.Matches(command, chatMessageImage));
		}

		public bool Matches(UpdateChatMessageCommand command, ICollection<ChatMessageImage> entities)
		{
			return r.MatchesCollection(
				entities,
				response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
				chatMessageImage => chatMessageImage.Id,
				(r, chatMessageImage) => r.Matches(command, chatMessageImage));
		}

		public bool Matches(DeleteChatMessageCommand command, ICollection<ChatMessageImage> entities)
		{
			return r.MatchesCollection(
				entities,
				response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
				chatMessageImage => chatMessageImage.Id,
				(r, chatMessageImage) => r.Matches(command, chatMessageImage));
		}

		public bool MatchesInverted(AddChatMessageCommand command, ICollection<ChatMessageImage> entities)
		{
			return command.Images.IsEmpty() ||
				   r.MatchesCollection(
					   entities,
					   response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
					   chatMessageImage => chatMessageImage.Id,
					   (r, chatMessageImage) => r.MatchesInverted(command, chatMessageImage));
		}

		public bool MatchesInverted(UpdateChatMessageCommand command, ICollection<ChatMessageImage> entities)
		{
			return r.MatchesCollection(
				entities,
				response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
				chatMessageImage => chatMessageImage.Id,
				(r, chatMessageImage) => r.MatchesInverted(command, chatMessageImage));
		}

		public bool MatchesInverted(DeleteChatMessageCommand command, ICollection<ChatMessageImage> entities)
		{
			return r.MatchesCollection(
				entities,
				response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
				chatMessageImage => chatMessageImage.Id,
				(r, chatMessageImage) => r.MatchesInverted(command, chatMessageImage));
		}
	}

	extension(ChatNotificationRequest request)
	{
		public bool Matches(AddChatMessageCommand command, Chat? entity)
		{
			return entity != null &&
				   request.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.ParticipantOneId.Id) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.ParticipantTwoId.Id) &&
				   request.ParticipantOne.MatchesParticipantOne(command, entity.ParticipantOne) &&
				   request.ParticipantTwo.MatchesParticipantTwo(command, entity.ParticipantTwo) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(UpdateChatMessageCommand command, Chat? entity)
		{
			return entity != null &&
				   request.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantTwoId.Id) &&
				   request.ParticipantOne.MatchesParticipantOne(command, entity.ParticipantOne) &&
				   request.ParticipantTwo.MatchesParticipantTwo(command, entity.ParticipantTwo) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeleteChatMessageCommand command, Chat? entity)
		{
			return entity != null &&
				   request.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantTwoId.Id) &&
				   request.ParticipantOne.MatchesParticipantOne(command, entity.ParticipantOne) &&
				   request.ParticipantTwo.MatchesParticipantTwo(command, entity.ParticipantTwo) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(AddChatMessageCommand command, Chat? entity)
		{
			return entity != null &&
				   request.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.ParticipantTwoId.Id) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.ParticipantOneId.Id) &&
				   request.ParticipantOne.MatchesParticipantTwo(command, entity.ParticipantOne) &&
				   request.ParticipantTwo.MatchesParticipantOne(command, entity.ParticipantTwo) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(UpdateChatMessageCommand command, Chat? entity)
		{
			return entity != null &&
				   request.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantTwoId.Id) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   request.ParticipantOne.MatchesParticipantTwo(command, entity.ParticipantOne) &&
				   request.ParticipantTwo.MatchesParticipantOne(command, entity.ParticipantTwo) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(DeleteChatMessageCommand command, Chat? entity)
		{
			return entity != null &&
				   request.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantTwoId.Id) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   request.ParticipantOne.MatchesParticipantTwo(command, entity.ParticipantOne) &&
				   request.ParticipantTwo.MatchesParticipantOne(command, entity.ParticipantTwo) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(UserNotificationRequest request)
	{
		public bool MatchesSender(AddChatMessageCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.ParticipantOneId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesSender(UpdateChatMessageCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesSender(DeleteChatMessageCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesSenderInverted(AddChatMessageCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.ParticipantTwoId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesSenderInverted(UpdateChatMessageCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesSenderInverted(DeleteChatMessageCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesParticipantOne(AddChatMessageCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.ParticipantOneId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesParticipantOne(UpdateChatMessageCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesParticipantOne(DeleteChatMessageCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesParticipantTwo(AddChatMessageCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.ParticipantTwoId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesParticipantTwo(UpdateChatMessageCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantTwoId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesParticipantTwo(DeleteChatMessageCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantTwoId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(ChatMessage chatMessage)
	{
		public bool Matches(AddChatMessageCommand command)
		{
			return chatMessage.Id.Id.Matches(command.Id) &&
				   chatMessage.Id.MessageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   chatMessage.SenderId.Matches(command.Id.ParticipantOneId) &&
				   chatMessage.Content == command.Content &&
				   chatMessage.Summary.Matches(chatMessage.GetSummary(command)) &&
				   chatMessage.CreatedAtUtc != default &&
				   chatMessage.UpdatedAtUtc != default;
		}

		public bool Matches(UpdateChatMessageCommand command)
		{
			return chatMessage.Id.Matches(command.Id) &&
				   chatMessage.SenderId.Matches(command.Id.Id.ParticipantOneId) &&
				   chatMessage.Content == command.Content &&
				   chatMessage.Summary.Matches(chatMessage.GetSummary(command)) &&
				   chatMessage.CreatedAtUtc != default &&
				   chatMessage.UpdatedAtUtc != default;
		}

		public bool Matches(DeleteChatMessageCommand command)
		{
			return chatMessage.Id.Matches(command.Id) &&
				   chatMessage.SenderId.Matches(command.Id.Id.ParticipantOneId) &&
				   chatMessage.Content.IsNotNullOrEmptyOrWhiteSpace() &&
				   chatMessage.CreatedAtUtc != default &&
				   chatMessage.UpdatedAtUtc != default;
		}

		public bool MatchesInverted(AddChatMessageCommand command)
		{
			return chatMessage.Id.Id.Matches(command.Id.ParticipantTwoId, command.Id.ParticipantOneId) &&
				   chatMessage.Id.MessageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   chatMessage.SenderId.Matches(command.Id.ParticipantTwoId) &&
				   chatMessage.Content == command.Content &&
				   chatMessage.Summary.Matches(chatMessage.GetSummary(command)) &&
				   chatMessage.CreatedAtUtc != default &&
				   chatMessage.UpdatedAtUtc != default;
		}

		public bool MatchesInverted(UpdateChatMessageCommand command)
		{
			return chatMessage.Id.Matches(new(command.Id.Id.ParticipantTwoId, command.Id.Id.ParticipantOneId), command.Id.MessageId) &&
				   chatMessage.SenderId.Matches(command.Id.Id.ParticipantOneId) &&
				   chatMessage.Content == command.Content &&
				   chatMessage.Summary.Matches(chatMessage.GetSummary(command)) &&
				   chatMessage.CreatedAtUtc != default &&
				   chatMessage.UpdatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllChatMessagesQuery query)
		{
			return (chatMessage.Id.Id.ParticipantOneId.Matches(query.CurrentUser.Id) &&
				   chatMessage.Id.Id.ParticipantTwoId.Matches(query.Filter.Id.ParticipantTwoId)) ||
				   (chatMessage.Id.Id.ParticipantOneId.Matches(query.Filter.Id.ParticipantTwoId) &&
				   chatMessage.Id.Id.ParticipantTwoId.Matches(query.CurrentUser.Id));
		}
	}

	extension(Url p)
	{
		public bool Matches(AddChatMessageCommand command)
		{
			return command.Images.ContainsUrl(p);
		}
	}

	extension(ICollection<Url> p)
	{
		public bool Matches(AddChatMessageCommand command)
		{
			return p.AllAndNotEmpty(u => u.Matches(command));
		}
	}

	extension(ChatMessageImage p)
	{
		public bool Matches(AddChatMessageCommand command)
		{
			return p.Id.Id.Id.Matches(command.Id) &&
				   p.Id.Id.MessageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   p.Id.ImageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   p.Url.Matches(command) &&
				   p.CreatedAtUtc != default;
		}

		public bool MatchesInverted(AddChatMessageCommand command)
		{
			return p.Id.Id.Id.Matches(command.Id.ParticipantTwoId, command.Id.ParticipantOneId) &&
				   p.Id.Id.MessageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   p.Id.ImageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   p.Url.Matches(command) &&
				   p.CreatedAtUtc != default;
		}
	}

	extension(ICollection<ChatMessageImage> p)
	{
		public bool Matches(AddChatMessageCommand command)
		{
			return p.AllAndNotEmpty(pi => pi.Matches(command));
		}

		public bool MatchesInverted(AddChatMessageCommand command)
		{
			return p.AllAndNotEmpty(pi => pi.MatchesInverted(command));
		}
	}

	extension(ChatMessageResponse? response)
	{
		public bool MatchesFull<TQuery>(TQuery request, ChatMessage? chatMessage)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.Id) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFull(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat.MatchesFull(request, chatMessage.Chat);
		}

		public bool MatchesFullInverted<TQuery>(TQuery request, ChatMessage? chatMessage)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(new(response.Id.Id.ParticipantTwoId, response.Id.Id.ParticipantOneId), response.Id.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFullInverted(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat.MatchesFullInverted(request, chatMessage.Chat);
		}

		public bool MatchesWithoutChat<TQuery>(TQuery request, ChatMessage? chatMessage)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.Id) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFull(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat == null;
		}

		public bool MatchesWithoutChatInverted<TQuery>(TQuery request, ChatMessage? chatMessage)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(new(response.Id.Id.ParticipantTwoId, response.Id.Id.ParticipantOneId), response.Id.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFullInverted(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat == null;
		}

		public bool Matches(GetChatMessageByIdQuery query, ChatMessage chatMessage)
		{
			return response.MatchesFull(query, chatMessage);
		}

		public bool MatchesInverted(GetChatMessageByIdQuery query, ChatMessage chatMessage)
		{
			return response.MatchesFullInverted(query, chatMessage);
		}
	}

	extension(ChatMessageCollectionResponse response)
	{
		public bool MatchesWithoutSender<TQuery>(
			TQuery request,
			Func<ChatMessageResponse, ChatMessage, bool> matches,
			Func<ChatMessage, bool> matchesFilter,
			Chat chat,
			ICollection<ChatMessage> chatMessages)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<ChatMessagesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFull(request, chat) &&
				   response.ChatMessages.MatchesCollection(request.Pagination,
														   chatMessages,
														   response => response.Id,
														   chatMessage => chatMessage.Id,
														   matches,
														   matchesFilter);
		}

		public bool MatchesWithoutSender<TQuery>(
			TQuery request,
			Func<ChatMessageResponse, ChatMessage, bool> matches,
			Func<ChatMessage, bool> matchesFilter,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<ChatMessagesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFull(request, chat) &&
				   response.ChatMessages.MatchesSortedCollection(request.Pagination,
																 chatMessages,
																 matches,
																 termTransformer,
																 matchesFilter);
		}

		public bool MatchesWithoutSenderInverted<TQuery>(
			TQuery request,
			Func<ChatMessageResponse, ChatMessage, bool> matches,
			Func<ChatMessage, bool> matchesFilter,
			Chat chat,
			ICollection<ChatMessage> chatMessages)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<ChatMessagesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFullInverted(request, chat) &&
				   response.ChatMessages.MatchesCollection(request.Pagination,
														   chatMessages,
														   response => new(new(response.Id.Id.ParticipantTwoId, response.Id.Id.ParticipantOneId), response.Id.MessageId),
														   chatMessage => chatMessage.Id,
														   matches,
														   matchesFilter);
		}

		public bool MatchesWithoutSenderInverted<TQuery>(
			TQuery request,
			Func<ChatMessageResponse, ChatMessage, bool> matches,
			Func<ChatMessage, bool> matchesFilter,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<ChatMessagesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFullInverted(request, chat) &&
				   response.ChatMessages.MatchesSortedCollection(request.Pagination,
																 chatMessages,
																 matches,
																 termTransformer,
																 matchesFilter);
		}

		public bool Matches(
			GetAllChatMessagesQuery query,
			Chat chat,
			ICollection<ChatMessage> chatMessages)
		{
			return response.MatchesWithoutSender(
					   query,
					   (response, chatMessage) => response.MatchesWithoutChat(query, chatMessage),
					   chatMessage => chatMessage.MatchesFilter(query),
					   chat,
					   chatMessages);
		}

		public bool Matches(
			GetAllChatMessagesQuery query,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			return response.MatchesWithoutSender(
					   query,
					   (response, chatMessage) => response.MatchesWithoutChat(query, chatMessage),
					   chatMessage => chatMessage.MatchesFilter(query),
					   chat,
					   chatMessages,
					   termTransformer);
		}

		public bool MatchesInverted(
			GetAllChatMessagesQuery query,
			Chat chat,
			ICollection<ChatMessage> chatMessages)
		{
			return response.MatchesWithoutSenderInverted(
					   query,
					   (response, chatMessage) => response.MatchesWithoutChatInverted(query, chatMessage),
					   chatMessage => chatMessage.MatchesFilter(query),
					   chat,
					   chatMessages);
		}

		public bool MatchesInverted(
			GetAllChatMessagesQuery query,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			return response.MatchesWithoutSenderInverted(
					   query,
					   (response, chatMessage) => response.MatchesWithoutChatInverted(query, chatMessage),
					   chatMessage => chatMessage.MatchesFilter(query),
					   chat,
					   chatMessages,
					   termTransformer);
		}
	}
}
