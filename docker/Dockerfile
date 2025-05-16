# Stage 1: Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy .csproj files
COPY src/BFF/BFF.csproj BFF/
COPY src/Inventory_Service_API/Inventory_Service_API.csproj Inventory_Service_API/
COPY src/Payment_Service_API/Payment_Service_API.csproj Payment_Service_API/

# Restore projects
RUN dotnet restore BFF/BFF.csproj
RUN dotnet restore Inventory_Service_API/Inventory_Service_API.csproj
RUN dotnet restore Payment_Service_API/Payment_Service_API.csproj

# Copy full source
COPY src/BFF/ BFF/
COPY src/Inventory_Service_API/ Inventory_Service_API/
COPY src/Payment_Service_API/ Payment_Service_API/

# Publish all
RUN dotnet publish BFF/BFF.csproj -c Release -o /app/bff --no-restore
RUN dotnet publish Inventory_Service_API/Inventory_Service_API.csproj -c Release -o /app/inventory --no-restore
RUN dotnet publish Payment_Service_API/Payment_Service_API.csproj -c Release -o /app/payment --no-restore

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

# Copy published apps
COPY --from=build /app/bff ./bff
COPY --from=build /app/inventory ./inventory
COPY --from=build /app/payment ./payment

# Copy and make start script executable
COPY docker/start.sh ./start.sh
RUN chmod +x ./start.sh

# Expose ports used by each API (update if needed)
EXPOSE 80 81 82

# Run all APIs with the script
ENTRYPOINT ["./start.sh"]
