# Etapa base do runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /LojaDoValdir
COPY ["LojaDoValdir/LojaDoValdir.csproj", "LojaDoValdir"]
RUN dotnet restore "LojaDoValdir/LojaDoValdir.csproj"
COPY . .

WORKDIR /LojaDoValdir
RUN dotnet build "LojaDoValdir.csproj" -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "LojaDoValdir.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LojaDoValdir.dll"]