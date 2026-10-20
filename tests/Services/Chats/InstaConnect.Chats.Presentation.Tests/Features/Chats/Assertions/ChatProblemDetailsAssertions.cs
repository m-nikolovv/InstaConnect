using InstaConnect.Chats.Domain.Features.Chats.Utilities;
using InstaConnect.Chats.Presentation.Tests.Features.Users.Assertions;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Assertions;

public static class ChatProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyParticipantOneNotFound(
			AddChatApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.ParticipantOneId);
		}

		public void ShouldSatisfyParticipantOneNotFound(
			GetAllChatsApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.CurrentUserId);
		}

		public void ShouldSatisfyParticipantTwoNotFound(
			AddChatApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.Body.ParticipantTwoId);
		}

		public void ShouldSatisfyChatNotFound(
			GetChatByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyChatNotFound(
				request,
				r => r.CurrentUserId,
				r => r.ParticipantTwoId);
		}

		public void ShouldSatisfyChatAlreadyExists(
			AddChatApiRequest request)
		{
			problemDetails.ShouldSatisfyChatAlreadyExists(
				request,
				r => r.ParticipantOneId,
				r => r.Body.ParticipantTwoId);
		}

		internal void ShouldSatisfyChatNotFound<TRequest>(
			TRequest request,
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression)
		{
			problemDetails.ShouldSatisfyNotFound(
				ChatExceptionErrorMessages.GetNotFoundMessage(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request)))));
		}

		internal void ShouldSatisfyChatAlreadyExists<TRequest>(
			TRequest request,
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				ChatExceptionErrorMessages.GetAlreadyExistsMessage(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request)))));
		}
	}
}
