# Use the build environment to restore and build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy the project file(s) and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the application source code
COPY . ./

# Build the application
RUN dotnet publish -c Release -o out

# Use a runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Copy the published application from the build environment
COPY --from=build-env /app/out .

# Expose a port if your application listens on a specific port
EXPOSE 80

# Specify the entry point for your application
ENTRYPOINT ["dotnet", "CommandService.dll"]
