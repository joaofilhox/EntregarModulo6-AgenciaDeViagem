# Fase de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia a solução e restaura dependências
COPY AgenciaDeViagem.sln .
COPY AgenciaDeViagem/AgenciaDeViagem.csproj AgenciaDeViagem/
RUN dotnet restore

# Copia todos os arquivos e constrói a aplicação
COPY . .
WORKDIR "/src/AgenciaDeViagem"
RUN dotnet build -c Release -o /app/build

# Fase de testes
FROM build AS testing
WORKDIR /src/AgenciaDeViagem.Tests
RUN dotnet test

# Fase de publicação
FROM build AS publish
WORKDIR /src/AgenciaDeViagem
RUN dotnet publish -c Release -o /src/publish

# Fase de execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
ENTRYPOINT ["dotnet", "AgenciaDeViagem.dll"]
