# Use the .NET 7.0.401 SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:7.0.401 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . .

# Build the application
RUN dotnet publish -c Release -o out

# Use a smaller runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0.401 AS runtime

# Set the working directory
WORKDIR /app

# Copy the built application from the build stage
COPY --from=build /app/out .

# Expose a port if your application listens on one (update with your port)
EXPOSE 80

# Start your application
ENTRYPOINT ["dotnet", "EvenTech.dll"]