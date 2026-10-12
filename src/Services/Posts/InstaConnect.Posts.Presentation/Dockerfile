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
COPY ["src/Services/Posts/InstaConnect.Posts.Presentation/InstaConnect.Posts.Presentation.csproj", "src/Services/Posts/InstaConnect.Posts.Presentation/"]
COPY ["src/Common/InstaConnect.Common.Presentation/InstaConnect.Common.Presentation.csproj", "src/Common/InstaConnect.Common.Presentation/"]
COPY ["src/Common/InstaConnect.Common.Application/InstaConnect.Common.Application.csproj", "src/Common/InstaConnect.Common.Application/"]
COPY ["src/Common/InstaConnect.Common.Domain/InstaConnect.Common.Domain.csproj", "src/Common/InstaConnect.Common.Domain/"]
COPY ["src/Common/InstaConnect.Common.Events/InstaConnect.Common.Events.csproj", "src/Common/InstaConnect.Common.Events/"]
COPY ["src/Common/InstaConnect.Common.Infrastructure/InstaConnect.Common.Infrastructure.csproj", "src/Common/InstaConnect.Common.Infrastructure/"]
COPY ["src/Services/Posts/InstaConnect.Posts.Application/InstaConnect.Posts.Application.csproj", "src/Services/Posts/InstaConnect.Posts.Application/"]
COPY ["src/Services/Posts/InstaConnect.Posts.Domain/InstaConnect.Posts.Domain.csproj", "src/Services/Posts/InstaConnect.Posts.Domain/"]
COPY ["src/Services/Posts/InstaConnect.Posts.Events/InstaConnect.Posts.Events.csproj", "src/Services/Posts/InstaConnect.Posts.Events/"]
COPY ["src/Services/Identity/InstaConnect.Identity.Events/InstaConnect.Identity.Events.csproj", "src/Services/Identity/InstaConnect.Identity.Events/"]
COPY ["src/Services/Posts/InstaConnect.Posts.Infrastructure/InstaConnect.Posts.Infrastructure.csproj", "src/Services/Posts/InstaConnect.Posts.Infrastructure/"]
RUN dotnet restore "./src/Services/Posts/InstaConnect.Posts.Presentation/InstaConnect.Posts.Presentation.csproj"
COPY . .
WORKDIR "/src/src/Services/Posts/InstaConnect.Posts.Presentation"
RUN dotnet build "./InstaConnect.Posts.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InstaConnect.Posts.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstaConnect.Posts.Presentation.dll"]
