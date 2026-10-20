using InstaConnect.Common.Domain.Features.ValueObjects.Models;

using Microsoft.Extensions.AI;

namespace InstaConnect.Common.Infrastructure.Features.Summarizers.Mappings;

public class SummarizerInfrastructureMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<ChatResponse, Summary>()
			.ConstructUsing(src => new(src.Text));
	}
}
