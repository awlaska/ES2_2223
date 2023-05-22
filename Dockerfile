FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EngSoft2.csproj", "./"]
RUN dotnet restore "EngSoft2.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "EngSoft2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EngSoft2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EngSoft2.dll"]
