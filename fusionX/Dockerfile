# Use a imagem base do .NET Core correspondente à versão do SDK especificada no arquivo YAML
FROM mcr.microsoft.com/dotnet/sdk:${{ env.DOTNET_VERSION }} AS build

# Define o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copie o código fonte do seu aplicativo para o contêiner
COPY . .

# Restaure as dependências do projeto
RUN dotnet restore

# Compile o aplicativo
RUN dotnet build --configuration Release --no-restore

# Publicar o aplicativo
RUN dotnet publish --configuration Release --no-restore --output /app/publish

# Use uma imagem base do ASP.NET Core para criar a imagem final
FROM mcr.microsoft.com/dotnet/aspnet:${{ env.DOTNET_VERSION }} AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "EvenTech.dll"]