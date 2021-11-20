FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ConsoleCache/ConsoleCache.csproj", "ConsoleCache/"]
RUN dotnet restore "ConsoleCache/ConsoleCache.csproj"
COPY . .
WORKDIR "/src/ConsoleCache"
RUN dotnet build "ConsoleCache.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsoleCache.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleCache.dll"]