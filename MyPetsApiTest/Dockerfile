#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MyPetsApiTest/MyPetsApiTest.csproj", "MyPetsApiTest/"]
COPY ["MyPetsAPI/MyPetsAPI.csproj", "MyPetsAPI/"]
COPY ["MyPetsCore/MyPetsCore.csproj", "MyPetsCore/"]
RUN dotnet restore "MyPetsApiTest/MyPetsApiTest.csproj"
COPY . .
WORKDIR "/src/MyPetsApiTest"
RUN dotnet build "MyPetsApiTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyPetsApiTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyPetsApiTest.dll"]