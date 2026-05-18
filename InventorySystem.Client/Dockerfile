# BUILD STAGE
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY . .

RUN dotnet restore "InventorySystem.Client/InventorySystem.Client.csproj"

RUN dotnet publish "InventorySystem.Client/InventorySystem.Client.csproj" \
    -c Release \
    -o /app/publish

# RUNTIME STAGE
FROM nginx:alpine

WORKDIR /usr/share/nginx/html

COPY --from=build /app/publish/wwwroot .

COPY InventorySystem.Client/nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80