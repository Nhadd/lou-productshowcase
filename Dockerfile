# Use .NET SDK for build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ["LOU.ProductShowcase.sln", "."]
COPY ["LOU.ProductShowcase/LOU.ProductShowcase.csproj", "LOU.ProductShowcase/"]

# Restore dependencies
RUN dotnet restore "LOU.ProductShowcase.sln"

# Copy the full source code
COPY . .

# Build and publish
WORKDIR "/src/LOU.ProductShowcase"
RUN dotnet publish "LOU.ProductShowcase.csproj" -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "LOU.ProductShowcase.dll"]
