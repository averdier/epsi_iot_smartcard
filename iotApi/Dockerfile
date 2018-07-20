FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 59454
EXPOSE 44355

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY iotApi.csproj ./
RUN dotnet restore ./iotApi.csproj
COPY . .
WORKDIR /src/
RUN dotnet build iotApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish iotApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
