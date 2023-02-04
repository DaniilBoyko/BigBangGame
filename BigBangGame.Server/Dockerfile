FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["BigBangGame.Server.csproj", "BigBangGame.Server/"]
RUN dotnet restore "BigBangGame.Server/BigBangGame.Server.csproj"

COPY ["", "BigBangGame.Server"]
WORKDIR "/src/BigBangGame.Server"
RUN dotnet build "BigBangGame.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BigBangGame.Server.csproj" -c Release -o /app/publish --self-contained false --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 5000
ENTRYPOINT ["dotnet", "BigBangGame.Server.dll"]