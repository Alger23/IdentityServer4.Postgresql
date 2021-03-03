#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["WebApiSampleCasbin/WebApiSampleCasbin.csproj", "WebApiSampleCasbin/"]
RUN dotnet restore "WebApiSampleCasbin/WebApiSampleCasbin.csproj"
COPY . .
WORKDIR "/src/WebApiSampleCasbin"
RUN dotnet build "WebApiSampleCasbin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApiSampleCasbin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiSampleCasbin.dll"]