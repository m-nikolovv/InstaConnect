using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMatchAssertions
{
	extension(User user)
	{
		public void ShouldSatisfy(VerifyForgotPasswordTokenApiRequest request, IPasswordHasher passwordHasher)
		{
			user.ShouldSatisfy(p => p.Matches(request, passwordHasher));
		}
	}

	extension(ICollection<ForgotPasswordToken> forgotPasswordTokens)
	{
		public void ShouldSatisfy(AddForgotPasswordTokenApiRequest request)
		{
			forgotPasswordTokens.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(ICollection<ForgotPasswordTokenAddedEventRequest> r)
	{
		public void ShouldSatisfy(AddForgotPasswordTokenApiRequest request, ICollection<ForgotPasswordToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(request, entities));
		}
	}

	extension(ICollection<ForgotPasswordTokenDeletedEventRequest> r)
	{
		public void ShouldSatisfy(VerifyForgotPasswordTokenApiRequest request, ICollection<ForgotPasswordToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(request, entities));
		}
	}
}
