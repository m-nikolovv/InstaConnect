using InstaConnect.Chats.Domain.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyChatNotFound(
			AddChatMessageApiRequest request)
		{
			problemDetails.ShouldSatisfyChatNotFound(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId);
		}

		public void ShouldSatisfyChatNotFound(
			UpdateChatMessageApiRequest request)
		{
			problemDetails.ShouldSatisfyChatNotFound(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId);
		}

		public void ShouldSatisfyChatNotFound(
			DeleteChatMessageApiRequest request)
		{
			problemDetails.ShouldSatisfyChatNotFound(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId);
		}

		public void ShouldSatisfyChatNotFound(
			GetChatMessageByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyChatNotFound(
				request,
				r => r.CurrentUserId,
				r => r.ParticipantTwoId);
		}

		public void ShouldSatisfyChatNotFound(
			GetAllChatMessagesApiRequest request)
		{
			problemDetails.ShouldSatisfyChatNotFound(
				request,
				r => r.CurrentUserId,
				r => r.ParticipantTwoId);
		}

		public void ShouldSatisfyChatMessageNotFound(
			UpdateChatMessageApiRequest request)
		{
			problemDetails.ShouldSatisfyChatMessageNotFound(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				r => r.MessageId);
		}

		public void ShouldSatisfyChatMessageNotFound(
			DeleteChatMessageApiRequest request)
		{
			problemDetails.ShouldSatisfyChatMessageNotFound(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				r => r.MessageId);
		}

		public void ShouldSatisfyChatMessageNotFound(
			GetChatMessageByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyChatMessageNotFound(
				request,
				r => r.CurrentUserId,
				r => r.ParticipantTwoId,
				r => r.MessageId);
		}

		public void ShouldSatisfyChatMessageForbidden(
			DeleteChatMessageApiRequest request)
		{
			problemDetails.ShouldSatisfyChatMessageForbidden(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				r => r.MessageId,
				r => r.ParticipantOneId);
		}

		public void ShouldSatisfyChatMessageForbidden(
			UpdateChatMessageApiRequest request)
		{
			problemDetails.ShouldSatisfyChatMessageForbidden(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				r => r.MessageId,
				r => r.ParticipantOneId);
		}

		internal void ShouldSatisfyChatMessageNotFound<TRequest>(
			TRequest request,
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression,
			Func<TRequest, string> messageIdPropertyExpression)
		{
			problemDetails.ShouldSatisfyNotFound(ChatMessageExceptionErrorMessages.GetNotFoundMessage(new(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request))), messageIdPropertyExpression(request))));
		}

		internal void ShouldSatisfyChatMessageForbidden<TRequest>(
			TRequest request,
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression,
			Func<TRequest, string> messageIdPropertyExpression,
			Func<TRequest, string> senderIdPropertyExpression)
		{
			problemDetails.ShouldSatisfyForbidden(ChatMessageExceptionErrorMessages.GetForbiddenMessage(new(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request))), messageIdPropertyExpression(request)), new(senderIdPropertyExpression(request))));
		}
	}
}
