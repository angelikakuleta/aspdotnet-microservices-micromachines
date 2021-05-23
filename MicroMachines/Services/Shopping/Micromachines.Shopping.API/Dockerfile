#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Services/Shopping/Micromachines.Shopping.API/MicroMachines.Shopping.API.csproj", "Services/Shopping/Micromachines.Shopping.API/"]
COPY ["Services/Shopping/Micromachines.Shopping.Domain/MicroMachines.Shopping.Domain.csproj", "Services/Shopping/Micromachines.Shopping.Domain/"]
COPY ["Common/MicroMachines.EventBus/MicroMachines.EventBus.csproj", "Common/MicroMachines.EventBus/"]
COPY ["Services/Shopping/Micromachines.Shopping.Infrastructure/MicroMachines.Shopping.Infrastructure.csproj", "Services/Shopping/Micromachines.Shopping.Infrastructure/"]
RUN dotnet restore "Services/Shopping/Micromachines.Shopping.API/MicroMachines.Shopping.API.csproj"
COPY . .
WORKDIR "/src/Services/Shopping/Micromachines.Shopping.API"
RUN dotnet build "MicroMachines.Shopping.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroMachines.Shopping.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroMachines.Shopping.API.dll"]