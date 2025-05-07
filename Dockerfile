# Uses original image from dotnet avaiable on: https://github.com/dotnet/dotnet-docker/tree/main
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Criar um diretório  
WORKDIR /app

# Copia csproj e restaura depêndencias
COPY *.csproj ./
RUN dotnet restore

# Copy all files from project to directory (except the specifies on .dockerignore)
COPY . /app
RUN dotnet publish -c Release -o /app/out

# Segundo build - produção
FROM mcr.microsoft.com/dotnet/sdk:9.0
WORKDIR /app
COPY --from=build /app/out .

# Execute the project
ENTRYPOINT ["dotnet", "digital_menu.dll"]