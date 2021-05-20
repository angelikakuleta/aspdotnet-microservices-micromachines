#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Services/MicroMachines.Basket.API/MicroMachines.Basket.API.csproj", "Services/MicroMachines.Basket.API/"]
RUN dotnet restore "Services/MicroMachines.Basket.API/MicroMachines.Basket.API.csproj"
COPY . .
WORKDIR "/src/Services/MicroMachines.Basket.API"
RUN dotnet build "MicroMachines.Basket.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroMachines.Basket.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroMachines.Basket.API.dll"]