cd /src
dotnet ef migration add initMig
dotnet ef database update
cd /app
dotnet iotApi.dll