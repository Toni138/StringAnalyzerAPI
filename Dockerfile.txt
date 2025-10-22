# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything
COPY . .

# Restore and publish the project
RUN dotnet restore StringAnalyzerAPI/StringAnalyzerAPI.csproj
RUN dotnet publish StringAnalyzerAPI/StringAnalyzerAPI.csproj -c Release -o /app/out

# Use a smaller runtime image for production
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "StringAnalyzerAPI.dll"]
