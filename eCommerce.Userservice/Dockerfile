FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt-get update && apt-get install -y libgssapi-krb5-2 && rm -rf /var/lib/apt/lists/*
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# 1. Copy project files using the exact folder name
COPY ["eCommerce.Userservice/Ecommerce.Userservice.csproj", "eCommerce.Userservice/eCommerce.Userservice.csproj"]
COPY ["eCommerce.Core/eCommerce.Core.csproj", "eCommerce.Core/"]
COPY ["eCommerce.Infrastructure/eCommerce.Infrastructure.csproj", "eCommerce.Infrastructure/"]

# 2. Restore using the exact path
RUN dotnet restore "eCommerce.Userservice/eCommerce.Userservice.csproj"

# 3. Copy everything else
COPY . .

# 4. CRITICAL: Switch to the correct lowercase folder
WORKDIR "/src/eCommerce.Userservice"

# 5. Build
RUN dotnet build "eCommerce.Userservice.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "eCommerce.Userservice.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV POSTGRES_HOST=localhost
ENV POSTGRES_PASSWORD=admin
ENTRYPOINT ["dotnet", "eCommerce.Userservice.dll"]