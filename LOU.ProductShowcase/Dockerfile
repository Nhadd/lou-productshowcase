# Use SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ["LOU.ProductShowcase.sln", "."]
COPY ["LOU.ProductShowcase/LOU.ProductShowcase.csproj", "LOU.ProductShowcase/"]

# Restore dependencies
RUN dotnet restore

# Copy the rest of the app
COPY . .

# Build and publish
WORKDIR /src/LOU.ProductShowcase
RUN dotnet publish -c Release -o /app/publish

# Use runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "LOU.ProductShowcase.dll"]
