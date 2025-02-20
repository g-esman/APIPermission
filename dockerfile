FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY PermissionsAPI.sln .
COPY API/API.csproj ./API/
COPY Application/Application.csproj ./Application/
COPY Domain/Domain.csproj ./Domain/
COPY Infrastructure/Infrastructure.csproj ./Infrastructure/

RUN dotnet restore

COPY . . 
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY --from=build /app/out .

EXPOSE 80

# Inicia la aplicación
ENTRYPOINT ["dotnet", "API.dll"]