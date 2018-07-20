sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-sdk-2.1
cd /src
dotnet ef migration add initMig
dotnet ef database update
cd /app
dotnet iotApi.dll