FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Install clang/zlib1g-dev dependencies for publishing to native
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    clang zlib1g-dev
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FlexLabs.Phonetics/FlexLabs.Phonetics.csproj", "FlexLabs.Phonetics/"]
RUN dotnet restore "FlexLabs.Phonetics/FlexLabs.Phonetics.csproj"
COPY . .
WORKDIR "/src/FlexLabs.Phonetics"
RUN dotnet build "FlexLabs.Phonetics.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FlexLabs.Phonetics.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=true

FROM mcr.microsoft.com/dotnet/runtime-deps:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["./FlexLabs.Phonetics"]
