# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM mcr.microsoft.com/dotnet/sdk:9.0-windowsservercore-ltsc2022 AS build
WORKDIR /source

# Copy project file and restore as distinct layers
COPY --link src/Bdziam.UI/*.csproj .
RUN dotnet restore

# Copy source code and publish app
COPY --link src/Bdziam.UI/. .
RUN dotnet publish --no-restore -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0-windowsservercore-ltsc2022
EXPOSE 8080
WORKDIR /app
COPY --link --from=build /app .
USER ContainerUser
ENTRYPOINT ["aspnetapp"]