using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Presentation.Features.Exceptions.Models;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageValidationProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyInvalidValidationForParticipantOneId(
			AddChatMessageApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.ParticipantOneId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForParticipantOneId(
			UpdateChatMessageApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.ParticipantOneId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForParticipantOneId(
			DeleteChatMessageApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.ParticipantOneId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForParticipantOneId(
			GetChatMessageByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentUserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForParticipantOneId(
			GetAllChatMessagesApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentUserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForParticipantTwoId(
			UpdateChatMessageApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.ParticipantTwoId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForParticipantTwoId(
			DeleteChatMessageApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.ParticipantTwoId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForParticipantTwoId(
			GetChatMessageByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.ParticipantTwoId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForParticipantTwoId(
			GetAllChatMessagesApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.ParticipantTwoId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForParticipantTwoId(
			AddChatMessageApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.ParticipantTwoId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForMessageId(
			UpdateChatMessageApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.MessageId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForMessageId(
			DeleteChatMessageApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.MessageId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForMessageId(
			GetChatMessageByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.MessageId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForContent(
			AddChatMessageApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Form.Content,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForContent(
			UpdateChatMessageApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Body.Content,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentUserId(
			GetChatMessageByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentUserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentUserId(
			GetAllChatMessagesApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentUserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPage(
			GetAllChatMessagesApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Page,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPageSize(
			GetAllChatMessagesApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.PageSize,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortOrder(
			GetAllChatMessagesApiRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortOrder,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortTerm(
			GetAllChatMessagesApiRequest request,
			IEnumMessageTransformer<ChatMessagesSortTerm> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortTerm,
				messageTransformer);
		}
	}
}
