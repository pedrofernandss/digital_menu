# Uses original image from dotnet avaiable on: https://github.com/dotnet/dotnet-docker/tree/main
FROM mcr.microsoft.com/dotnet/sdk:9.0

# Create directory  
WORKDIR /app

# Copy all files from project to directory (except the specifies on .dockerignore)
COPY . /app

# Execute the project on dev mode
ENTRYPOINT ["dotnet run --watch"]