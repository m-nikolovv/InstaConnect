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
COPY ["src/Services/Chats/InstaConnect.Chats.Presentation/InstaConnect.Chats.Presentation.csproj", "src/Services/Chats/InstaConnect.Chats.Presentation/"]
COPY ["src/Common/InstaConnect.Common.Presentation/InstaConnect.Common.Presentation.csproj", "src/Common/InstaConnect.Common.Presentation/"]
COPY ["src/Common/InstaConnect.Common.Application/InstaConnect.Common.Application.csproj", "src/Common/InstaConnect.Common.Application/"]
COPY ["src/Common/InstaConnect.Common.Domain/InstaConnect.Common.Domain.csproj", "src/Common/InstaConnect.Common.Domain/"]
COPY ["src/Common/InstaConnect.Common.Events/InstaConnect.Common.Events.csproj", "src/Common/InstaConnect.Common.Events/"]
COPY ["src/Common/InstaConnect.Common.Infrastructure/InstaConnect.Common.Infrastructure.csproj", "src/Common/InstaConnect.Common.Infrastructure/"]
COPY ["src/Services/Chats/InstaConnect.Chats.Application/InstaConnect.Chats.Application.csproj", "src/Services/Chats/InstaConnect.Chats.Application/"]
COPY ["src/Services/Chats/InstaConnect.Chats.Domain/InstaConnect.Chats.Domain.csproj", "src/Services/Chats/InstaConnect.Chats.Domain/"]
COPY ["src/Services/Chats/InstaConnect.Chats.Events/InstaConnect.Chats.Events.csproj", "src/Services/Chats/InstaConnect.Chats.Events/"]
COPY ["src/Services/Identity/InstaConnect.Identity.Events/InstaConnect.Identity.Events.csproj", "src/Services/Identity/InstaConnect.Identity.Events/"]
COPY ["src/Services/Chats/InstaConnect.Chats.Infrastructure/InstaConnect.Chats.Infrastructure.csproj", "src/Services/Chats/InstaConnect.Chats.Infrastructure/"]
RUN dotnet restore "./src/Services/Chats/InstaConnect.Chats.Presentation/InstaConnect.Chats.Presentation.csproj"
COPY . .
WORKDIR "/src/src/Services/Chats/InstaConnect.Chats.Presentation"
RUN dotnet build "./InstaConnect.Chats.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InstaConnect.Chats.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstaConnect.Chats.Presentation.dll"]
