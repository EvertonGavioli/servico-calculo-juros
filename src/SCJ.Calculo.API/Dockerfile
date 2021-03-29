#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/SCJ.Calculo.API/SCJ.Calculo.API.csproj", "src/SCJ.Calculo.API/"]
RUN dotnet restore "src/SCJ.Calculo.API/SCJ.Calculo.API.csproj"
COPY . .
WORKDIR "/src/src/SCJ.Calculo.API"
RUN dotnet build "SCJ.Calculo.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SCJ.Calculo.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SCJ.Calculo.API.dll"]