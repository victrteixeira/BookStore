FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["*.sln", "."]
COPY ["Catalog.API/*.csproj", "Catalog.API/"]
COPY ["Catalog.IoC/*.csproj", "Catalog.IoC/"]
COPY ["Catalog.Core/*.csproj", "Catalog.Core/"]
COPY ["Catalog.Infra/*.csproj", "Catalog.Infra/"]
COPY ["Catalog.Application/*.csproj", "Catalog.Application/"]

RUN dotnet restore "Catalog.API/Catalog.API.csproj"
COPY . .

WORKDIR "/src/Catalog.API"
RUN dotnet build "Catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog.API.dll"]
