FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Backfy.Api/Backfy.Api.csproj", "src/Backfy.Api/"]
RUN dotnet restore "src/Backfy.Api/Backfy.Api.csproj"
COPY . .
WORKDIR "/src/src/Backfy.Api"
RUN dotnet build "Backfy.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Backfy.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Backfy.Api.dll"]