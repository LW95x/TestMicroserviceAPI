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
COPY ["MicroserviceAPI.Orders.csproj", "./"]

RUN dotnet restore "MicroserviceAPI.Orders.csproj"

# Copy the remaining source code and build the project
COPY . .
RUN dotnet build "MicroserviceAPI.Orders.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MicroserviceAPI.Orders.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Set the environment to Development
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "MicroserviceAPI.Orders.dll"]
