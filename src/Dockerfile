FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./PromoCodeFactory.WebHost/PromoCodeFactory.WebHost.csproj" --disable-parallel
RUN dotnet publish "./PromoCodeFactory.WebHost/PromoCodeFactory.WebHost.csproj" -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT [ "dotnet", "PromoCodeFactory.WebHost.dll"]