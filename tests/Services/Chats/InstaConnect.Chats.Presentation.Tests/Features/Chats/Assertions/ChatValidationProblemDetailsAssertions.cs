namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Assertions;

public static class ChatValidationProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyInvalidValidationForParticipantOneId(
			AddChatApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.ParticipantOneId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForParticipantTwoId(
			GetChatByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.ParticipantTwoId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForParticipantTwoId(
			AddChatApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Body.ParticipantTwoId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentUserId(
			GetChatByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentUserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentUserId(
			GetAllChatsApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentUserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForParticipantTwoName(
			GetAllChatsApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.ParticipantTwoName,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPage(
			GetAllChatsApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Page,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPageSize(
			GetAllChatsApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.PageSize,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortOrder(
			GetAllChatsApiRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortOrder,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortTerm(
			GetAllChatsApiRequest request,
			IEnumMessageTransformer<ChatsSortTerm> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortTerm,
				messageTransformer);
		}
	}
}
