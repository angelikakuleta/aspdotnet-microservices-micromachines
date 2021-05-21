#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Services/Shopping/Shopping.API/MicroMachines.Shopping.API.csproj", "Services/Shopping/Shopping.API/"]
COPY ["Services/Shopping/Shopping.Infrastructure/MicroMachines.Shopping.Infrastructure.csproj", "Services/Shopping/Shopping.Infrastructure/"]
COPY ["Services/Shopping/Shopping.Domain/MicroMachines.Shopping.Domain.csproj", "Services/Shopping/Shopping.Domain/"]
RUN dotnet restore "Services/Shopping/Shopping.API/MicroMachines.Shopping.API.csproj"
COPY . .
WORKDIR "/src/Services/Shopping/Shopping.API"
RUN dotnet build "MicroMachines.Shopping.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroMachines.Shopping.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroMachines.Shopping.API.dll"]