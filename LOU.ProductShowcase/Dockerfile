# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["LOU.ProductShowcase.sln", "."]
COPY ["LOU.ProductShowcase/LOU.ProductShowcase.csproj", "LOU.ProductShowcase/"]
RUN dotnet restore "LOU.ProductShowcase.sln"

COPY . .
WORKDIR "/src/LOU.ProductShowcase"
RUN dotnet publish -c Release -o /app/publish

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "LOU.ProductShowcase.dll"]
