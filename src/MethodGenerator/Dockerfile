FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MethodGenerator/MethodGenerator.csproj", "MethodGenerator/"]
RUN dotnet restore "MethodGenerator/MethodGenerator.csproj"
COPY . .
RUN dotnet build -c $BUILD_CONFIGURATION
RUN dotnet test

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MethodGenerator/MethodGenerator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MethodGenerator.dll"]