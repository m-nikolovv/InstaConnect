using System.Linq.Expressions;

using FluentValidation.TestHelper;

using InstaConnect.Common.Application.Tests.Features.Utilities;
using InstaConnect.Common.Tests.Features.Assertions;
using InstaConnect.Common.Tests.Features.DataAttributes.Base;

namespace InstaConnect.Common.Application.Tests.Features.Assertions;

public static class ValidationAssertions
{
	extension<TRequest>(TestValidationResult<TRequest> testValidationResult)
	{
		public void ShouldHaveValidationErrorForProperty<TProperty>(
			TRequest request,
			Expression<Func<TRequest, TProperty>> memberAccessor,
			IMessageTransformer<TProperty> messageTransformer)
		{
			testValidationResult
				.ShouldHaveValidationErrorFor(memberAccessor)
				.ShouldContain(p => p.Matches(messageTransformer.Transform(memberAccessor, memberAccessor.Compile()(request))));
		}

		public void ShouldNotHaveAnyValidationErrorProperties()
		{
			testValidationResult.ShouldNotHaveAnyValidationErrors();
		}
	}
}
