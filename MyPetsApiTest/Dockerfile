#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MyPetsCore/MyPetsCore.csproj", "MyPetsCore/"]
COPY ["MyPetsAPI/MyPetsAPI.csproj", "MyPetsAPI/"]
COPY ["MyPetsApiTest/MyPetsApiTest.csproj", "MyPetsApiTest/"]
RUN dotnet restore "MyPetsCore/MyPetsCore.csproj"
RUN dotnet restore "MyPetsAPI/MyPetsAPI.csproj"
RUN dotnet restore "MyPetsApiTest/MyPetsApiTest.csproj"
COPY . .
RUN dotnet clean
RUN dotnet build "MyPetsCore/MyPetsCore.csproj" -c Release --no-restore
RUN dotnet build "MyPetsAPI/MyPetsAPI.csproj" -c Release --no-restore
RUN dotnet build "MyPetsApiTest.csproj" -c Debug --no-restore

FROM build AS publish
RUN dotnet publish "MyPetsApiTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyPetsApiTest.dll"]