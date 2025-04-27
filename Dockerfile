# Usa imagem base oficial do .NET para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia apenas o projeto principal
COPY Fluxo_Caixa.csproj ./
RUN dotnet restore

# Copia todo o restante do projeto principal (sem .sln, sem projeto de teste)
COPY . ./

# Ajuste aqui: publica apenas o csproj do projeto principal
RUN dotnet publish Fluxo_Caixa.csproj -c Release -o out

# Usa imagem base oficial do .NET para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expõe a porta 80
EXPOSE 80

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "Fluxo_Caixa.dll"]
