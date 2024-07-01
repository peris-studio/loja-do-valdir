FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/LojaDoValdir/LojaDoValdir.csproj", "src/LojaDoValdir/"]
RUN dotnet restore "src/LojaDoValdir/LojaDoValdir.csproj"
COPY . .
WORKDIR "/src/src/LojaDoValdir"
RUN dotnet build "LojaDoValdir.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "LojaDoValdir.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LojaDoValdir.dll"]
