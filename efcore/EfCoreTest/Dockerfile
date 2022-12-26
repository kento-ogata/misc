FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src

COPY ["./EfCoreTest.csproj", "./EfCoreTest.csproj"]
RUN dotnet restore
COPY [".", "."]
RUN dotnet publish "EfCoreTest.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "EfCoreTest.dll"]
