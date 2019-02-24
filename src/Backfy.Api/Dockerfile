FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/Backfy.Api/Backfy.Api.csproj src/Backfy.Api/
COPY src/Sales/Backfy.Sales.Command/Backfy.Sales.Command.csproj src/Sales/Backfy.Sales.Command/
COPY src/Albums/Backfy.Albums.Repository/Backfy.Albums.Repository.csproj src/Albums/Backfy.Albums.Repository/
COPY src/Backfy.Common.Infra/Backfy.Common.Infra.csproj src/Backfy.Common.Infra/
COPY src/Sales/Backfy.Sales.Repository/Backfy.Sales.Repository.csproj src/Sales/Backfy.Sales.Repository/
COPY src/Sales/Backfy.Sales.Query/Backfy.Sales.Query.csproj src/Sales/Backfy.Sales.Query/
COPY src/Albums/Backfy.Albums.Query/Backfy.Albums.Query.csproj src/Albums/Backfy.Albums.Query/
RUN dotnet restore src/Backfy.Api/Backfy.Api.csproj
COPY . .
WORKDIR /src/src/Backfy.Api
RUN dotnet build Backfy.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Backfy.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Backfy.Api.dll"]
