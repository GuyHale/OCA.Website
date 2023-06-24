#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OCA.Website/OCA.Website.csproj", "OCA.Website/"]
RUN dotnet restore "OCA.Website/OCA.Website.csproj"
COPY . .
WORKDIR "/src/OCA.Website"
RUN dotnet build "OCA.Website.csproj" -c Release -o /app/build

FROM build AS publish
RUN \ 
  apt update && \
  apt install -y ca-certificates && \
  update-ca-certificates
RUN dotnet publish "OCA.Website.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OCA.Website.dll"]