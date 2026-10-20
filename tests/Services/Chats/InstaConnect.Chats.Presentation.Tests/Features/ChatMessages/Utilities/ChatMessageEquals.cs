using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;
using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Delete;
using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetById;
using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Entities;
using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Requests;
using InstaConnect.Chats.Domain.Features.Users.Models.Requests;
using InstaConnect.Chats.Presentation.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Presentation.Tests.Features.Users.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Requests.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.Extensions;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageEquals
{
	extension(ChatMessageAddedNotificationRequest r)
	{
		public bool Matches(AddChatMessageApiRequest request, ChatMessage entity)
		{
			return r.ChatMessage.Matches(request, entity);
		}

		public bool MatchesInverted(AddChatMessageApiRequest request, ChatMessage entity)
		{
			return r.ChatMessage.MatchesInverted(request, entity);
		}
	}

	extension(ChatMessageUpdatedNotificationRequest r)
	{
		public bool Matches(UpdateChatMessageApiRequest request, ChatMessage entity)
		{
			return r.ChatMessage.Matches(request, entity);
		}

		public bool MatchesInverted(UpdateChatMessageApiRequest request, ChatMessage entity)
		{
			return r.ChatMessage.MatchesInverted(request, entity);
		}
	}

	extension(ChatMessageDeletedNotificationRequest r)
	{
		public bool Matches(DeleteChatMessageApiRequest request, ChatMessage entity)
		{
			return r.ChatMessage.Matches(request, entity);
		}

		public bool MatchesInverted(DeleteChatMessageApiRequest request, ChatMessage entity)
		{
			return r.ChatMessage.MatchesInverted(request, entity);
		}
	}

	extension(ChatMessageNotificationRequest r)
	{
		public bool Matches(AddChatMessageApiRequest request, ChatMessage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(entity.Id.MessageId) &&
				   r.Sender.MatchesSender(request, entity.Sender) &&
				   r.Chat.Matches(request, entity.Chat) &&
				   r.ChatMessageImages.Matches(request, entity.ChatMessageImages) &&
				   r.Content == request.Form.Content &&
				   r.Summary == entity.GetSummary(request) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(UpdateChatMessageApiRequest request, ChatMessage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(request.MessageId) &&
				   r.Sender.MatchesSender(request, entity.Sender) &&
				   r.Chat.Matches(request, entity.Chat) &&
				   r.ChatMessageImages.Matches(request, entity.ChatMessageImages) &&
				   r.Content == request.Body.Content &&
				   r.Summary == entity.GetSummary(request) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeleteChatMessageApiRequest request, ChatMessage? entity)
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

		public bool MatchesInverted(AddChatMessageApiRequest request, ChatMessage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(entity.Id.MessageId) &&
				   r.Sender.MatchesSenderInverted(request, entity.Sender) &&
				   r.Chat.MatchesInverted(request, entity.Chat) &&
				   r.ChatMessageImages.MatchesInverted(request, entity.ChatMessageImages) &&
				   r.Content == request.Form.Content &&
				   r.Summary == entity.GetSummary(request) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesInverted(UpdateChatMessageApiRequest request, ChatMessage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(request.MessageId) &&
				   r.Sender.MatchesSenderInverted(request, entity.Sender) &&
				   r.Chat.MatchesInverted(request, entity.Chat) &&
				   r.ChatMessageImages.MatchesInverted(request, entity.ChatMessageImages) &&
				   r.Content == request.Body.Content &&
				   r.Summary == entity.GetSummary(request) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesInverted(DeleteChatMessageApiRequest request, ChatMessage? entity)
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
		public bool Matches(AddChatMessageApiRequest request, ChatMessageImage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(entity.Id.Id.MessageId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   request.Form.Images.ContainsUrl(r.Url) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(UpdateChatMessageApiRequest request, ChatMessageImage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(request.MessageId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeleteChatMessageApiRequest request, ChatMessageImage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(request.MessageId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(AddChatMessageApiRequest request, ChatMessageImage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(entity.Id.Id.MessageId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   request.Form.Images.ContainsUrl(r.Url) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(UpdateChatMessageApiRequest request, ChatMessageImage? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.MessageId.EqualsOrdinalIgnoreCase(request.MessageId) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(DeleteChatMessageApiRequest request, ChatMessageImage? entity)
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
		public bool Matches(AddChatMessageApiRequest request, ICollection<ChatMessageImage> entities)
		{
			return request.Form.Images.IsEmpty() ||
				   r.MatchesCollection(
					   entities,
					   response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
					   chatMessageImage => chatMessageImage.Id,
					   (r, chatMessageImage) => r.Matches(request, chatMessageImage));
		}

		public bool Matches(UpdateChatMessageApiRequest request, ICollection<ChatMessageImage> entities)
		{
			return r.MatchesCollection(
				entities,
				response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
				chatMessageImage => chatMessageImage.Id,
				(r, chatMessageImage) => r.Matches(request, chatMessageImage));
		}

		public bool Matches(DeleteChatMessageApiRequest request, ICollection<ChatMessageImage> entities)
		{
			return r.MatchesCollection(
				entities,
				response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
				chatMessageImage => chatMessageImage.Id,
				(r, chatMessageImage) => r.Matches(request, chatMessageImage));
		}

		public bool MatchesInverted(AddChatMessageApiRequest request, ICollection<ChatMessageImage> entities)
		{
			return request.Form.Images.IsEmpty() ||
				   r.MatchesCollection(
					   entities,
					   response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
					   chatMessageImage => chatMessageImage.Id,
					   (r, chatMessageImage) => r.MatchesInverted(request, chatMessageImage));
		}

		public bool MatchesInverted(UpdateChatMessageApiRequest request, ICollection<ChatMessageImage> entities)
		{
			return r.MatchesCollection(
				entities,
				response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
				chatMessageImage => chatMessageImage.Id,
				(r, chatMessageImage) => r.MatchesInverted(request, chatMessageImage));
		}

		public bool MatchesInverted(DeleteChatMessageApiRequest request, ICollection<ChatMessageImage> entities)
		{
			return r.MatchesCollection(
				entities,
				response => new(new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId), response.ImageId),
				chatMessageImage => chatMessageImage.Id,
				(r, chatMessageImage) => r.MatchesInverted(request, chatMessageImage));
		}
	}

	extension(ChatNotificationRequest r)
	{
		public bool Matches(AddChatMessageApiRequest request, Chat? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantOne.MatchesParticipantOne(request, entity.ParticipantOne) &&
				   r.ParticipantTwo.MatchesParticipantTwo(request, entity.ParticipantTwo) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(UpdateChatMessageApiRequest request, Chat? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantOne.MatchesParticipantOne(request, entity.ParticipantOne) &&
				   r.ParticipantTwo.MatchesParticipantTwo(request, entity.ParticipantTwo) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeleteChatMessageApiRequest request, Chat? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantOne.MatchesParticipantOne(request, entity.ParticipantOne) &&
				   r.ParticipantTwo.MatchesParticipantTwo(request, entity.ParticipantTwo) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(AddChatMessageApiRequest request, Chat? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantOne.MatchesParticipantTwo(request, entity.ParticipantOne) &&
				   r.ParticipantTwo.MatchesParticipantOne(request, entity.ParticipantTwo) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(UpdateChatMessageApiRequest request, Chat? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantOne.MatchesParticipantTwo(request, entity.ParticipantOne) &&
				   r.ParticipantTwo.MatchesParticipantOne(request, entity.ParticipantTwo) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool MatchesInverted(DeleteChatMessageApiRequest request, Chat? entity)
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
		public bool MatchesSender(AddChatMessageApiRequest request, User? entity)
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

		public bool MatchesSender(UpdateChatMessageApiRequest request, User? entity)
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

		public bool MatchesSender(DeleteChatMessageApiRequest request, User? entity)
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

		public bool MatchesSenderInverted(AddChatMessageApiRequest request, User? entity)
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

		public bool MatchesSenderInverted(UpdateChatMessageApiRequest request, User? entity)
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

		public bool MatchesSenderInverted(DeleteChatMessageApiRequest request, User? entity)
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

		public bool MatchesParticipantOne(AddChatMessageApiRequest request, User? entity)
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

		public bool MatchesParticipantOne(UpdateChatMessageApiRequest request, User? entity)
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

		public bool MatchesParticipantOne(DeleteChatMessageApiRequest request, User? entity)
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

		public bool MatchesParticipantTwo(AddChatMessageApiRequest request, User? entity)
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

		public bool MatchesParticipantTwo(UpdateChatMessageApiRequest request, User? entity)
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

		public bool MatchesParticipantTwo(DeleteChatMessageApiRequest request, User? entity)
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

	extension(GetAllChatMessagesQueryRequest query)
	{
		public bool Matches(GetAllChatMessagesApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllChatMessagesQueryRequest, ChatMessagesSortTerm, GetAllChatMessagesApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllChatMessagesApiRequest request)
		{
			return query.ParticipantTwoId == request.ParticipantTwoId;
		}
	}

	extension(GetChatMessageByIdQueryRequest query)
	{
		public bool Matches(GetChatMessageByIdApiRequest request)
		{
			return query.ParticipantTwoId == request.ParticipantTwoId &&
				   query.MessageId == request.MessageId &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddChatMessageCommandRequest command)
	{
		public bool Matches(AddChatMessageApiRequest request)
		{
			return command.ParticipantOneId == request.ParticipantOneId &&
				   command.ParticipantTwoId == request.ParticipantTwoId &&
				   command.Content == request.Form.Content &&
				   command.Images == request.Form.Images;
		}
	}

	extension(UpdateChatMessageCommandRequest command)
	{
		public bool Matches(UpdateChatMessageApiRequest request)
		{
			return command.ParticipantOneId == request.ParticipantOneId &&
				   command.ParticipantTwoId == request.ParticipantTwoId &&
				   command.MessageId == request.MessageId &&
				   command.Content == request.Body.Content;
		}
	}

	extension(DeleteChatMessageCommandRequest command)
	{
		public bool Matches(DeleteChatMessageApiRequest request)
		{
			return command.ParticipantOneId == request.ParticipantOneId &&
				   command.ParticipantTwoId == request.ParticipantTwoId &&
				   command.MessageId == request.MessageId;
		}
	}

	extension(AddChatMessageApiResponse response)
	{
		public bool Matches(
		AddChatMessageApiRequest request,
		ChatMessage chatMessage)
		{
			return response.Response.Matches(chatMessage.Id);
		}
	}

	extension(UpdateChatMessageApiResponse response)
	{
		public bool Matches(
		UpdateChatMessageApiRequest request,
		ChatMessage chatMessage)
		{
			return response.Response.Matches(chatMessage.Id);
		}
	}

	extension(GetChatMessageByIdApiResponse response)
	{
		public bool Matches(GetChatMessageByIdApiRequest request, ChatMessage chatMessage)
		{
			return response.Response.MatchesFull(request, chatMessage);
		}

		public bool MatchesInverted(GetChatMessageByIdApiRequest request, ChatMessage chatMessage)
		{
			return response.Response.MatchesFullInverted(request, chatMessage);
		}
	}

	extension(GetAllChatMessagesApiResponse response)
	{
		public bool Matches(
		GetAllChatMessagesApiRequest request,
		Chat chat,
		ICollection<ChatMessage> chatMessages)
		{
			return response.Response.MatchesWithoutSender(
					   request,
					   (response, chatMessage) => response.MatchesWithoutChat(request, chatMessage),
					   chatMessage => chatMessage.MatchesFilter(request),
					   chat,
					   chatMessages);
		}

		public bool Matches(
			GetAllChatMessagesApiRequest request,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			return response.Response.MatchesWithoutSender(
					   request,
					   (response, chatMessage) => response.MatchesWithoutChat(request, chatMessage),
					   chatMessage => chatMessage.MatchesFilter(request),
					   chat,
					   chatMessages,
					   termTransformer);
		}

		public bool MatchesInverted(GetAllChatMessagesApiRequest request, Chat chat, ICollection<ChatMessage> chatMessages)
		{
			return response.Response.MatchesWithoutSenderInverted(
				request,
				(response, message) => response.MatchesWithoutChatInverted(request, message),
				message => message.MatchesFilter(request),
				chat,
				chatMessages);
		}

		public bool MatchesInverted(GetAllChatMessagesApiRequest request, Chat chat, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
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
		public bool Matches(AddChatMessageApiRequest request)
		{
			return chatMessage.Id.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId) &&
				   chatMessage.Id.MessageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   chatMessage.SenderId.Matches(request.ParticipantOneId) &&
				   chatMessage.Content == request.Form.Content &&
				   chatMessage.Summary.Matches(chatMessage.GetSummary(request)) &&
				   chatMessage.CreatedAtUtc != default &&
				   chatMessage.UpdatedAtUtc != default;
		}

		public bool Matches(UpdateChatMessageApiRequest request)
		{
			return chatMessage.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId, request.MessageId) &&
				   chatMessage.SenderId.Matches(request.ParticipantOneId) &&
				   chatMessage.Content == request.Body.Content &&
				   chatMessage.Summary.Matches(chatMessage.GetSummary(request)) &&
				   chatMessage.CreatedAtUtc != default &&
				   chatMessage.UpdatedAtUtc != default;
		}

		public bool MatchesInverted(AddChatMessageApiRequest request)
		{
			return chatMessage.Id.Id.Matches(request.ParticipantTwoId, request.ParticipantOneId) &&
				   chatMessage.Id.MessageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   chatMessage.SenderId.Matches(request.ParticipantTwoId) &&
				   chatMessage.Content == request.Form.Content &&
				   chatMessage.Summary.Matches(chatMessage.GetSummary(request)) &&
				   chatMessage.CreatedAtUtc != default &&
				   chatMessage.UpdatedAtUtc != default;
		}

		public bool MatchesInverted(UpdateChatMessageApiRequest request)
		{
			return chatMessage.Id.Matches(request.ParticipantTwoId, request.ParticipantOneId, request.MessageId) &&
				   chatMessage.SenderId.Matches(request.ParticipantOneId) &&
				   chatMessage.Content == request.Body.Content &&
				   chatMessage.Summary.Matches(chatMessage.GetSummary(request)) &&
				   chatMessage.CreatedAtUtc != default &&
				   chatMessage.UpdatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllChatMessagesApiRequest request)
		{
			return (chatMessage.Id.Id.ParticipantOneId.Matches(request.CurrentUserId) &&
				   chatMessage.Id.Id.ParticipantTwoId.Matches(request.ParticipantTwoId)) ||
				   (chatMessage.Id.Id.ParticipantOneId.Matches(request.ParticipantTwoId) &&
				   chatMessage.Id.Id.ParticipantTwoId.Matches(request.CurrentUserId));
		}
	}

	extension(ChatMessageImage chatMessageImage)
	{
		public bool Matches(AddChatMessageApiRequest request)
		{
			return chatMessageImage.Id.Id.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId) &&
				   chatMessageImage.Id.Id.MessageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   chatMessageImage.Id.ImageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   chatMessageImage.Url.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   chatMessageImage.CreatedAtUtc != default;
		}

		public bool MatchesInverted(AddChatMessageApiRequest request)
		{
			return chatMessageImage.Id.Id.Id.Matches(request.ParticipantTwoId, request.ParticipantOneId) &&
				   chatMessageImage.Id.Id.MessageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   chatMessageImage.Id.ImageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   chatMessageImage.Url.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   chatMessageImage.CreatedAtUtc != default;
		}
	}

	extension(ICollection<ChatMessageImage> chatMessageImages)
	{
		public bool Matches(AddChatMessageApiRequest request)
		{
			return chatMessageImages.AllAndNotEmpty(chatMessageImage => chatMessageImage.Matches(request));
		}

		public bool MatchesInverted(AddChatMessageApiRequest request)
		{
			return chatMessageImages.AllAndNotEmpty(chatMessageImage => chatMessageImage.MatchesInverted(request));
		}
	}

	extension(ChatMessageIdApiResponse response)
	{
		public bool Matches(ChatMessageId id)
		{
			return id.Matches(response.ParticipantOneId, response.ParticipantTwoId, response.MessageId);
		}
	}

	extension(ChatMessageApiResponse? response)
	{
		public bool MatchesFull<TRequest>(TRequest request, ChatMessage? chatMessage)
		where TRequest : ICurrentUserableApiRequest
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
			where TRequest : ICurrentUserableApiRequest
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
			where TRequest : ICurrentUserableApiRequest
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
			where TRequest : ICurrentUserableApiRequest
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
			where TRequest : ICurrentUserableApiRequest
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
			where TRequest : ICurrentUserableApiRequest
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

	extension(ChatMessageCollectionApiResponse response)
	{
		public bool MatchesWithoutSender<TRequest>(TRequest request, Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFull(request, chat) &&
				   response.ChatMessages.MatchesCollection(
					   request,
					   chatMessages,
					   response => new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId),
					   chatMessage => chatMessage.Id,
					   matches,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutSender<TRequest>(TRequest request, Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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

		public bool MatchesWithoutChat<TRequest>(TRequest request, Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender.MatchesFull(user) &&
				   response.Chat == null &&
				   response.ChatMessages.MatchesCollection(
					   request,
					   chatMessages,
					   response => new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId),
					   chatMessage => chatMessage.Id,
					   matches,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutChat<TRequest>(TRequest request, Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
		public bool MatchesWithoutSenderInverted<TRequest>(TRequest request, Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFullInverted(request, chat) &&
				   response.ChatMessages.MatchesCollection(
					   request,
					   chatMessages,
					   response => new(new(new(response.ParticipantTwoId), new(response.ParticipantOneId)), response.MessageId),
					   chatMessage => chatMessage.Id,
					   matches,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutSenderInverted<TRequest>(TRequest request, Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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

		public bool MatchesWithoutChatInverted<TRequest>(TRequest request, Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender.MatchesFull(user) &&
				   response.Chat == null &&
				   response.ChatMessages.MatchesCollection(
					   request,
					   chatMessages,
					   response => new(new(new(response.ParticipantTwoId), new(response.ParticipantOneId)), response.MessageId),
					   chatMessage => chatMessage.Id,
					   matches,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutChatInverted<TRequest>(TRequest request, Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
