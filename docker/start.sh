#!/bin/bash

# Start each API in the background
cd /app/bff
dotnet /app/bff/BFF.dll --urls=http://0.0.0.0:80 &

cd /app/inventory
dotnet /app/inventory/Inventory_Service_API.dll --urls=http://0.0.0.0:81 &

cd /app/payment
dotnet /app/payment/Payment_Service_API.dll --urls=http://0.0.0.0:82 &

# Wait for all background processes to keep the container running
wait