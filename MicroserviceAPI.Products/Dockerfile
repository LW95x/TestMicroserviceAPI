# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the project file and restore dependencies
COPY MicroserviceAPI.Products/MicroserviceAPI.Products.csproj MicroserviceAPI.Products/
WORKDIR /src/MicroserviceAPI.Products
RUN dotnet restore

# Copy the remaining source code and build the project
COPY MicroserviceAPI.Products/. .
RUN dotnet build "MicroserviceAPI.Products.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MicroserviceAPI.Products.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set the environment to Development
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "MicroserviceAPI.Products.dll"]
