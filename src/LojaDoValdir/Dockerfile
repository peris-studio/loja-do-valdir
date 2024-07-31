FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

LABEL maintainer "Hisllaylla Kezia"

USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["src/LojaDoValdir/LojaDoValdir.csproj", "src/LojaDoValdir/"]

RUN dotnet restore "./src/LojaDoValdir/./LojaDoValdir.csproj" -p:Configuration=${BUILD_CONFIGURATION}

COPY . .

WORKDIR "/src/src/LojaDoValdir"

FROM build AS publish

RUN dotnet publish -r linux-arm64 "./LojaDoValdir.csproj" --no-restore -c $BUILD_CONFIGURATION -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime-deps:8.0 AS final

WORKDIR /app
EXPOSE 8080

COPY --from=publish /app/publish .
ENTRYPOINT ["./LojaDoValdir"]
