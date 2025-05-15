# Etapa 1: build da aplica��o
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o projeto principal e restaura depend�ncias
COPY ["Fluxo_Caixa.csproj", "./"]
RUN dotnet restore

# Copia todos os arquivos da solu��o (exceto testes, se for o caso)
COPY . .

# Publica apenas o projeto principal
RUN dotnet publish "Fluxo_Caixa.csproj" -c Release -o /app/publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copia os arquivos publicados
COPY --from=build /app/publish .

# Exp�e porta padr�o para aplica��es web
EXPOSE 80

# Comando de entrada
ENTRYPOINT ["dotnet", "Fluxo_Caixa.dll"]
