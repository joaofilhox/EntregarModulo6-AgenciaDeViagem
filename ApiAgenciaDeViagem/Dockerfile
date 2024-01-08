# Fase de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo csproj e restaura dependências
COPY /*.csproj ApiAgenciaDeViagem/
RUN dotnet restore "ApiAgenciaDeViagem/ApiAgenciaDeViagem.csproj"

# Copia todos os arquivos e constrói a aplicação
COPY . .
WORKDIR "/src/ApiAgenciaDeViagem"
RUN dotnet build -c Release -o /app/build

# Fase de publicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia os arquivos da fase de construção
COPY --from=build /app .

EXPOSE 80
ENTRYPOINT ["dotnet", "ApiAgenciaDeViagem.dll"]
