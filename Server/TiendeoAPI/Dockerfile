FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5001

FROM microsoft/dotnet:2.1-sdk AS builder
ARG Configuration=Release
WORKDIR /src
COPY *.sln ./
COPY ServicesLibrary/ServicesLibrary.csproj ServicesLibrary/
COPY TiendeoAPI/TiendeoAPI.csproj TiendeoAPI/
RUN dotnet restore
COPY . .
WORKDIR /src/TiendeoAPI
RUN dotnet build -c $Configuration -o /app

FROM builder AS publish
ARG Configuration=Release
RUN dotnet publish -c $Configuration -o /app

FROM base AS final
WORKDIR /app
COPY TiendeoAPI/Data.json /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TiendeoAPI.dll"]