FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["GameNewsWeb/GameNewsWeb.csproj", "GameNewsWeb/"]
RUN dotnet restore "GameNewsWeb/GameNewsWeb.csproj"

COPY . .
WORKDIR "/src/GameNewsWeb"
RUN dotnet publish "GameNewsWeb.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "GameNewsWeb.dll"]
