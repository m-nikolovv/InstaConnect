FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["Directory.Build.props", "."]
COPY ["Directory.Build.targets", "."]
COPY ["src/Services/Identity/InstaConnect.Identity.Presentation/InstaConnect.Identity.Presentation.csproj", "src/Services/Identity/InstaConnect.Identity.Presentation/"]
COPY ["src/Common/InstaConnect.Common.Presentation/InstaConnect.Common.Presentation.csproj", "src/Common/InstaConnect.Common.Presentation/"]
COPY ["src/Common/InstaConnect.Common.Application/InstaConnect.Common.Application.csproj", "src/Common/InstaConnect.Common.Application/"]
COPY ["src/Common/InstaConnect.Common.Domain/InstaConnect.Common.Domain.csproj", "src/Common/InstaConnect.Common.Domain/"]
COPY ["src/Common/InstaConnect.Common.Events/InstaConnect.Common.Events.csproj", "src/Common/InstaConnect.Common.Events/"]
COPY ["src/Common/InstaConnect.Common.Infrastructure/InstaConnect.Common.Infrastructure.csproj", "src/Common/InstaConnect.Common.Infrastructure/"]
COPY ["src/Services/Identity/InstaConnect.Identity.Application/InstaConnect.Identity.Application.csproj", "src/Services/Identity/InstaConnect.Identity.Application/"]
COPY ["src/Services/Identity/InstaConnect.Identity.Domain/InstaConnect.Identity.Domain.csproj", "src/Services/Identity/InstaConnect.Identity.Domain/"]
COPY ["src/Services/Identity/InstaConnect.Identity.Events/InstaConnect.Identity.Events.csproj", "src/Services/Identity/InstaConnect.Identity.Events/"]
COPY ["src/Services/Identity/InstaConnect.Identity.Infrastructure/InstaConnect.Identity.Infrastructure.csproj", "src/Services/Identity/InstaConnect.Identity.Infrastructure/"]
RUN dotnet restore "./src/Services/Identity/InstaConnect.Identity.Presentation/InstaConnect.Identity.Presentation.csproj"
COPY . .
WORKDIR "/src/src/Services/Identity/InstaConnect.Identity.Presentation"
RUN dotnet build "./InstaConnect.Identity.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InstaConnect.Identity.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstaConnect.Identity.Presentation.dll"]
