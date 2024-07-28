FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PromoCodeFactory.WebHost/PromoCodeFactory.WebHost.csproj", "PromoCodeFactory.WebHost/"]
COPY ["PromoCodeFactory.Core/PromoCodeFactory.Core.csproj", "PromoCodeFactory.Core/"]
COPY ["PromoCodeFactory.DataAccess/PromoCodeFactory.DataAccess.csproj", "PromoCodeFactory.DataAccess/"]
RUN dotnet restore "./PromoCodeFactory.WebHost/PromoCodeFactory.WebHost.csproj"

COPY . .
WORKDIR "/src/PromoCodeFactory.WebHost"
RUN dotnet publish "./PromoCodeFactory.WebHost.csproj" -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT [ "dotnet", "PromoCodeFactory.WebHost.dll"]