namespace InstaConnect.Chats.Application.Tests.Features.Chats.Assertions;

public static class ChatValidationAssertions
{
	extension(TestValidationResult<GetChatByIdQueryRequest> response)
	{
		public void ShouldHaveValidationErrorForParticipantTwoId(
			GetChatByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.ParticipantTwoId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			GetChatByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}
	}

	extension(TestValidationResult<AddChatCommandRequest> response)
	{
		public void ShouldHaveValidationErrorForParticipantOneId(
			AddChatCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.ParticipantOneId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForParticipantTwoId(
			AddChatCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.ParticipantTwoId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllChatsQueryRequest> response)
	{
		public void ShouldHaveValidationErrorForParticipantTwoName(
			GetAllChatsQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.ParticipantTwoName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			GetAllChatsQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(
			GetAllChatsQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(
			GetAllChatsQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(
			GetAllChatsQueryRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(
			GetAllChatsQueryRequest request,
			IEnumMessageTransformer<ChatsSortTerm> messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}
}
