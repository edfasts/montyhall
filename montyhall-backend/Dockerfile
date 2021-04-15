FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["MontyHall.API/MontyHall.API.csproj", "MontyHall.API/"]
RUN dotnet restore "MontyHall.API/MontyHall.API.csproj"
COPY . .
WORKDIR "/src/MontyHall.API"
RUN dotnet build "MontyHall.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MontyHall.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MontyHall.API.dll"]
