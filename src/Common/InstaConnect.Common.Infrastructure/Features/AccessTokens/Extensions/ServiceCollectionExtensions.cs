using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Helpers;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Models;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Common.Infrastructure.Features.AccessTokens.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddAccessTokens(IConfiguration configuration)
		{
			serviceCollection.AddValidatedOptions<AccessTokenOptions>(AccessTokenOptions.SectionName);
			var options = configuration.GetOptions<AccessTokenOptions>(AccessTokenOptions.SectionName);

			serviceCollection.AddSingleton<IEncoder, Encoder>();
			serviceCollection.AddSingleton<IBaseAccessTokenGenerator, BaseAccessTokenGenerator>();

			serviceCollection.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(opt =>
			{
				var encoder = serviceCollection.BuildServiceProvider()
											  .GetRequiredService<IEncoder>();

				opt.TokenValidationParameters = new TokenValidationParameters
				{
					IssuerSigningKey = new SymmetricSecurityKey(encoder.GetBytesUTF8(options.SecurityKey)),
					ValidateIssuerSigningKey = options.ValidateIssuerSigningKey,
					ValidateIssuer = options.ValidateIssuer,
					ValidIssuer = options.Issuer,
					ValidateAudience = options.ValidateAudience,
					ValidAudience = options.Audience,
					ValidateLifetime = options.ValidateLifetime,
					ClockSkew = TimeSpan.FromSeconds(options.ClockSkewSeconds)
				};
			});

			return serviceCollection;
		}
	}
}
