FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
LABEL maintainer="Hisllaylla Kézia"
WORKDIR /app
EXPOSE 8080

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar o arquivo de projeto e restaurar dependências
COPY src/LojaDoValdir/LojaDoValdir.csproj LojaDoValdir/
RUN dotnet restore "LojaDoValdir/LojaDoValdir.csproj"

# Copiar o código restante
COPY src .

# Compilar a aplicação
WORKDIR "/src/LojaDoValdir"
RUN dotnet build "LojaDoValdir.csproj" -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "LojaDoValdir.csproj" -c Release -o /app/publish

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copiar a aplicação publicada
COPY --from=publish /app/publish .

# Configuração para rodar na porta 8080
ENV ASPNETCORE_URLS=http://0.0.0.0:8080

# Entrypoint para rodar a aplicação
ENTRYPOINT ["dotnet", "LojaDoValdir.dll"]