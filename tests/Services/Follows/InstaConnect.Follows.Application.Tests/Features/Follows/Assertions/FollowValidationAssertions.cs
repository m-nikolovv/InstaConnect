namespace InstaConnect.Follows.Application.Tests.Features.Follows.Assertions;

public static class FollowValidationAssertions
{
	extension(TestValidationResult<DeleteFollowCommandRequest> response)
	{
		public void ShouldHaveValidationErrorForFollowerId(
			DeleteFollowCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.FollowerId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFollowingId(
			DeleteFollowCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.FollowingId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetFollowByIdQueryRequest> response)
	{
		public void ShouldHaveValidationErrorForFollowerId(
			GetFollowByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.FollowerId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFollowingId(
			GetFollowByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.FollowingId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			GetFollowByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}
	}

	extension(TestValidationResult<AddFollowCommandRequest> response)
	{
		public void ShouldHaveValidationErrorForFollowerId(
			AddFollowCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.FollowerId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFollowingId(
			AddFollowCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.FollowingId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllFollowsQueryRequest> response)
	{
		public void ShouldHaveValidationErrorForFollowerId(
			GetAllFollowsQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.FollowerId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			GetAllFollowsQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFollowingName(
			GetAllFollowsQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.FollowingName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(
			GetAllFollowsQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(
			GetAllFollowsQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(
			GetAllFollowsQueryRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(
			GetAllFollowsQueryRequest request,
			IEnumMessageTransformer<FollowsSortTerm> messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllFollowsForFollowingQueryRequest> response)
	{
		public void ShouldHaveValidationErrorForFollowingId(
			GetAllFollowsForFollowingQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.FollowingId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFollowerName(
			GetAllFollowsForFollowingQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.FollowerName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			GetAllFollowsForFollowingQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(
			GetAllFollowsForFollowingQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(
			GetAllFollowsForFollowingQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(
			GetAllFollowsForFollowingQueryRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(
			GetAllFollowsForFollowingQueryRequest request,
			IEnumMessageTransformer<FollowsForFollowingSortTerm> messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}
}
